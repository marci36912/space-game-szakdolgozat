/**
	This class is an easy way to use RNG in Unity.  It is designed to solve a number of problems that
	RNG by itself does not solve.  
	
	
	
	There are three kinds of RNG in this class
	------------------------------------------
	EvenDistribution - This class features an even distribution of values between your upper and lower
		bounds.  It iterates between five sets of numbers from 0 to 100, which has been randomized.  It
		will always return values in the same order, but the starting value can be altered by seeding it.
		This type of RNG is useful for randomly selecting from a set of items, for example, if you have 
		ten items to chose from and they are all equallty weighted, you can select which you want using
		RNJesus.even().rangeInclusive_i(0, 9).
	
	BellCurveDistribution - This class has a distribution that has much higher weight in the middle of
		the upper and lower bound.  The median value is ten times as likely to show up as the two extremes.
		An example of when this is wanted is with a weapon that might perform between 10 and 20 damage,
		you want MOST of your shots to cause about 15.  RNJesus.bell().rangeInclusive_f(10, 20) will return
		a random value that's heavily weighted around 15.
	
	BooleanDistribution - This class is specifically for returning a true of false based on odds.  It is
		not a simple randomizer however, it will keep track of how many true/falses it returns in a row 
		and limits them based on what humans will perceive as correct, rather than what's mathematically
		random.  For example, flipping a coin using RNJesus.boolean().boolean(0.5) will never return a series
		of three of the same value in a row.
		
		
		
	These classes have a simple interface
	-------------------------------------
	double rangeInclusive_f(double lower, double upper)
	int rangeInclusive_i(int lower, int upper)
		These methods are what you will use most of the time, it'll return a random value between the lower
		and upper bounds, and may include the bounds themselves

	bool boolean(double odds = 0.5)	
		This method only exists in the BooleanDistribution class and will return true or false.  The odds tell
		the function how likely a true result is, and also determines how many trues or falses in a row it can 
		return.  For example, if the odds are .75, it can at most have 1 false in a row and at most 3 trues in 
		a row, not actually how probability works, but how humans perceive it
	
	void seed(int val)
		Provides a specific seed to the object. If you want your game to act differently every time, seed it
		with a timestamp on bootup, otherwise, ignore this function.  There is a static seed function as well
		as member functions per class.  When you call the static seed, all objects you create after that will
		use the same seed.
		
	void moveIterator()
		This allows you to move the iterator without actually calling a random number.  Useful to allowing input
		or events to move it forwards so that there appears more pseudorandomness.  For example, in Super Mario
		Maker 2, every time Mario jumps, it moves the RNG system, allowing it to be deteriministic without seeming
		like it.
		
		
		
	Singletons
	----------
	RNJesus.even()
	RNJesus.bell()
	RNJesus.boolean()
	
	
	
	Constructors
	------------
	new RNJesus.EvenDistribution()
	new RNJesus.BellCurveDistribution()
	new RNJesus.BooleanDistribution()
**/

public class RNJesus
{


	public static EvenDistribution even()
	{
		if (singletonEven == null) singletonEven = new EvenDistribution();
		return singletonEven;
	}

	public static BellCurveDistribution bell()
	{
		if (singletonBell == null) singletonBell = new BellCurveDistribution();
		return singletonBell;
	}

	public static BooleanDistribution boolean()
	{
		if (singletonBool == null) singletonBool = new BooleanDistribution();
		return singletonBool;
	}

	public static void seed(int val)
	{
		defaultSeed = val;
		if (singletonEven != null) singletonEven.seed(val);
		if (singletonBell != null) singletonBell.seed(val);
		if (singletonBool != null) singletonBool.seed(val);
	}




	public class EvenDistribution
	{
		public EvenDistribution() { seed(defaultSeed); }

		public virtual double rangeInclusive_f(double lower, double upper)
		{
			return adjust_f(((double)zeroToOneHundredInclusive[setIterator, internalIterator]) / 100.0, lower, upper);
		}

		public virtual int rangeInclusive_i(int lower, int upper)
		{
			return adjust_i((double)zeroToOneHundredInclusive[setIterator, internalIterator], lower, upper);
		}

		public virtual void seed(int val)
		{
			val = val % 505;
			setIterator = val / 101;
			internalIterator = val - setIterator * 101;
		}

		public virtual void moveIterator()
		{
			if (++internalIterator > 100)
			{
				internalIterator = 0;
				if (++setIterator > 4) setIterator = 0;
			}
		}

		protected double adjust_f(double val, double lower, double upper)
		{
			moveIterator();
			double range = upper - lower;
			return val * range + lower;
		}

		protected int adjust_i(double val, int lower, int upper)
		{
			moveIterator();

			int buckets = (upper - lower) + 1;
			double amountPerBucket = 100.0 / (double)buckets;
			buckets = (int)(val / amountPerBucket);
			return buckets > upper ? upper : buckets;  // Very top bucket will overflow by design
		}

		protected int setIterator = 0;
		protected int internalIterator = 0;
	}


	public class BellCurveDistribution : EvenDistribution
	{
		public BellCurveDistribution() { seed(defaultSeed); }

		public override double rangeInclusive_f(double lower, double upper)
		{
			return adjust_f(((double)(zeroToOneHundredInclusive[setIterator, internalIterator] + zeroToOneHundredInclusive[setIterator, internalIterator])) / 200.0, lower, upper);
		}

		public override int rangeInclusive_i(int lower, int upper)
		{
			double result = (double)zeroToOneHundredInclusive[setIterator, internalIterator] + (double)zeroToOneHundredInclusive[bellCurveSetIterator, bellCurveInternalIterator];
			return adjust_i(result / 2.0, lower, upper);
		}

		public override void seed(int val)
		{
			base.seed(val);
			val = val % 505;
			bellCurveSetIterator = val / 101;
			bellCurveInternalIterator = val - bellCurveSetIterator * 101;
			bellCurveSetIterator = 4 - bellCurveSetIterator;
			bellCurveInternalIterator = 100 - bellCurveInternalIterator;
		}

		public override void moveIterator()
		{
			base.moveIterator();
			moveSecondaryIterator = !moveSecondaryIterator;
			if (moveSecondaryIterator)
			{
				if (--bellCurveSetIterator < 0)
				{
					bellCurveSetIterator = 4;
					if (--bellCurveInternalIterator < 0) bellCurveInternalIterator = 100;
				}
			}
		}

		private bool moveSecondaryIterator = false;
		private int bellCurveSetIterator = 0;
		private int bellCurveInternalIterator = 0;
	}



	public class BooleanDistribution : EvenDistribution
	{
		public BooleanDistribution() { seed(defaultSeed); }

		public bool boolean(double odds = 0.5)
		{
			if (odds >= 1.0) return true;
			if (odds <= 0.0) return false;
			moveIterator();
			if ((double)zeroToOneHundredInclusive[setIterator, internalIterator] < odds * 100.0)
			{
				int mostTrueValuesInARow = (int)(1.0 / (1.0 - odds)) + 1;
				if (++trueAnswers > mostTrueValuesInARow)
				{
					falseAnswers = 1;
					trueAnswers = 0;
					return false;
				}
				falseAnswers = 0;
				return true;
			}

			int mostFalseValuesInARow = (int)(1.0 / odds) + 1;
			if (++falseAnswers > mostFalseValuesInARow)
			{
				trueAnswers = 1;
				falseAnswers = 0;
				return true;
			}
			trueAnswers = 0;
			return false;
		}

		public override void seed(int val)
		{
			base.seed(val);
			trueAnswers = falseAnswers = 0;
		}


		//These variables are used to count haw many T/F answeres get returned in a row and limits them based on the odds
		private int falseAnswers = 0;
		private int trueAnswers = 0;
	}


	private static EvenDistribution singletonEven;
	private static BellCurveDistribution singletonBell;
	private static BooleanDistribution singletonBool;
	private static int defaultSeed = 0;
	protected static int[,] zeroToOneHundredInclusive = new int[5, 101]{
		{43, 56, 78, 64, 16, 52, 81, 0, 89, 34, 33, 65, 100, 4, 55, 13, 94, 12, 85, 67, 8, 87, 90, 24, 73, 72, 91, 75, 92, 17, 77, 25, 47, 40, 18, 45, 83, 62, 96, 44, 27, 98, 59, 74, 48, 38, 1, 37, 99, 28, 95, 19, 61, 26, 50, 97, 80, 35, 71, 5, 23, 15, 84, 58, 69, 60, 93, 88, 11, 49, 10, 46, 20, 51, 2, 36, 32, 53, 30, 6, 41, 39, 14, 29, 70, 86, 76, 54, 7, 31, 9, 42, 21, 66, 79, 3, 82, 57, 22, 63, 68},
		{20, 90, 29, 72, 57, 40, 33, 45, 64, 62, 37, 81, 26, 82, 53, 38, 51, 86, 11, 98, 43, 99, 69, 16, 30, 17, 39, 27, 88, 74, 85, 92, 12, 70, 10, 54, 28, 46, 49, 15, 84, 6, 50, 60, 3, 32, 34, 35, 58, 96, 14, 2, 100, 67, 79, 73, 23, 7, 89, 18, 25, 42, 76, 5, 13, 78, 47, 75, 87, 56, 21, 9, 41, 59, 61, 36, 94, 0, 44, 8, 93, 55, 71, 1, 63, 66, 48, 22, 97, 52, 77, 19, 24, 80, 91, 65, 31, 68, 95, 4, 83},
		{96, 3, 7, 95, 54, 15, 12, 21, 48, 50, 43, 64, 1, 8, 99, 49, 89, 75, 9, 81, 0, 20, 63, 67, 25, 17, 58, 91, 76, 77, 28, 38, 51, 29, 80, 78, 56, 85, 98, 87, 11, 53, 73, 18, 65, 22, 23, 33, 47, 14, 94, 86, 57, 45, 37, 72, 16, 24, 39, 5, 27, 40, 74, 30, 2, 13, 68, 59, 46, 32, 83, 84, 55, 4, 31, 19, 79, 66, 44, 52, 60, 36, 82, 97, 69, 6, 26, 10, 42, 100, 41, 34, 71, 62, 88, 70, 35, 90, 92, 61, 93},
		{16, 72, 24, 1, 69, 89, 50, 41, 18, 93, 100, 76, 35, 21, 86, 11, 92, 32, 74, 73, 97, 44, 10, 15, 59, 17, 20, 6, 96, 31, 88, 36, 98, 2, 0, 67, 25, 43, 34, 60, 78, 26, 7, 5, 65, 70, 87, 3, 64, 13, 94, 51, 53, 39, 9, 68, 90, 80, 29, 62, 23, 85, 91, 22, 99, 66, 48, 30, 54, 63, 45, 38, 71, 12, 28, 77, 84, 40, 47, 49, 81, 95, 61, 57, 14, 56, 83, 19, 75, 79, 4, 52, 58, 33, 37, 82, 8, 55, 27, 42, 46},
		{6, 67, 52, 28, 39, 10, 59, 56, 75, 34, 27, 70, 20, 91, 86, 69, 38, 0, 44, 1, 80, 19, 83, 7, 77, 21, 32, 33, 90, 64, 43, 42, 47, 13, 14, 11, 12, 97, 72, 36, 84, 26, 16, 35, 85, 82, 58, 9, 68, 95, 30, 99, 40, 54, 87, 61, 3, 78, 17, 51, 89, 37, 2, 88, 18, 57, 31, 15, 25, 98, 66, 50, 8, 53, 93, 24, 79, 100, 48, 45, 74, 46, 60, 96, 81, 29, 71, 22, 55, 94, 4, 65, 23, 62, 76, 63, 92, 5, 73, 49, 41}
	};
}
