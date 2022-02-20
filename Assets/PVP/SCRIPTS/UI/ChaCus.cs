using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaCus : MonoBehaviour
{
    private ChaCus me;

    [Header("sprites")]
    [SerializeField] private Sprite[] hat;
    [SerializeField] private Sprite[] face;
    [SerializeField] private Color[] p1Colors;
    [SerializeField] private Color[] p2Colors;

    [Header("P1")]
    [SerializeField] private SpriteRenderer p1Hat;
    [SerializeField] private SpriteRenderer p1Face;
    [SerializeField] private SpriteRenderer p1;

    private static int p1hatActive = 0;
    private static int p1FaceActive = 0;
    private static int p1ColActive = 0;

    [Header("P2")]
    [SerializeField] private SpriteRenderer p2Hat;
    [SerializeField] private SpriteRenderer p2Face;
    [SerializeField] private SpriteRenderer p2;

    private static int p2hatActive = 0;
    private static int p2FaceActive = 0;
    private static int p2ColActive = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (me == null)
        {
            me = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        getRenderers();
        setSprites();
    }

    private void Start()
    {
        getRenderers();

        Time.timeScale = 0;

        setSprites();
    }
    private void getRenderers()
    {
        var P1 = GameObject.Find("P1");
        //Debug.Log(P1.name);

        var P1Face = P1.transform.Find("FaceParts");

        var P2 = GameObject.Find("P2");
        var P2Face = P2.transform.Find("FaceParts");

        p1Hat = P1Face.transform.Find("hat").GetComponent<SpriteRenderer>();
        p1Face = P1Face.transform.Find("face").GetComponent<SpriteRenderer>();
        p1 = P1.GetComponent<SpriteRenderer>();

        p2Hat = P2Face.transform.Find("hat").GetComponent<SpriteRenderer>();
        p2Face = P2Face.transform.Find("face").GetComponent<SpriteRenderer>();
        p2 = P2.GetComponent<SpriteRenderer>();
    }
    private void setSprites()
    {
        p1Hat.sprite = hat[p1hatActive];
        p1Face.sprite = face[p1FaceActive];
        p1.color = p1Colors[p1ColActive];

        p2Hat.sprite = hat[p2hatActive];
        p2Face.sprite = face[p2FaceActive];
        p2.color = p2Colors[p2ColActive];
    }
    #region p1
    public void P1NextHat()
    {
        p1hatActive++;

        if (p1hatActive == hat.Length)
        {
            p1hatActive = 0;
        }

        p1Hat.sprite = hat[p1hatActive];
    }
    public void P1PrevHat() 
    {
        p1hatActive--;

        if (p1hatActive < 0)
        {
            p1hatActive = hat.Length - 1;
        }

        p1Hat.sprite = hat[p1hatActive];
    }
    public void P1NextFace()
    {
        p1FaceActive++;

        if (p1FaceActive == face.Length)
        {
            p1FaceActive = 0;
        }

        p1Face.sprite = face[p1FaceActive];
    }
    public void P1PrevFace()
    {
        p1FaceActive--;

        if (p1FaceActive < 0)
        {
            p1FaceActive = face.Length - 1;
        }

        p1Face.sprite = face[p1FaceActive];
    }
    public void P1NextCol()
    {
        p1ColActive++;

        if (p1ColActive == p1Colors.Length)
        {
            p1ColActive = 0;
        }

        p1.color = p1Colors[p1ColActive];
    }
    public void P1PrevCol()
    {
        p1ColActive--;

        if (p1ColActive < 0)
        {
            p1ColActive = p1Colors.Length - 1;
        }

        p1.color = p1Colors[p1ColActive];
    }

    #endregion
    #region p2
    public void P2NextHat()
    {
        p2hatActive++;

        if (p2hatActive == hat.Length)
        {
            p2hatActive = 0;
        }

        p2Hat.sprite = hat[p2hatActive];
    }
    public void P2PrevHat()
    {
        p2hatActive--;

        if (p2hatActive < 0)
        {
            p2hatActive = hat.Length - 1;
        }

        p2Hat.sprite = hat[p2hatActive];
    }
    public void P2NextFace()
    {
        p2FaceActive++;

        if (p2FaceActive == face.Length)
        {
            p2FaceActive = 0;
        }

        p2Face.sprite = face[p2FaceActive];
    }
    public void P2PrevFace()
    {
        p2FaceActive--;

        if (p2FaceActive < 0)
        {
            p2FaceActive = face.Length - 1;
        }

        p2Face.sprite = face[p2FaceActive];
    }
    public void P2NextCol()
    {
        p2ColActive++;

        if (p2ColActive == p2Colors.Length)
        {
            p2ColActive = 0;
        }

        p2.color = p2Colors[p2ColActive];
    }
    public void P2PrevCol()
    {
        p2ColActive--;

        if (p2ColActive < 0)
        {
            p2ColActive = p2Colors.Length - 1;
        }

        p2.color = p2Colors[p2ColActive];
    }
    #endregion
}
