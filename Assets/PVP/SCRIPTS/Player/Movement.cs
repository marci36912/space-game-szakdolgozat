using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode jump;

    [SerializeField] private Transform fold;
    [SerializeField] private LayerMask foldLayer;

    private Rigidbody2D rb;

    private bool jobbra = false;
    private bool foldCheck = false;
    private bool ugrasKey = false;

    private float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        mozgas();

        if (Input.GetKeyDown(jump))
        {
            ugrasKey = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * 5, rb.velocity.y);
        megfordulas();

        ugras();
    }

    #region irany
    private void megfordulas()
    {
        if (jobbra == false && horizontal < 0)
        {
            irany();
        }
        else if (jobbra == true && horizontal > 0)
        {
            irany();
        }
    }
    public void irany()
    {
        jobbra = !jobbra;

        transform.Rotate(0f, 180f, 0f);
    }
    #endregion
    private void ugras()
    {
        foldCheck = Physics2D.OverlapCircle(fold.position, 0.05f, foldLayer);
        if (ugrasKey && foldCheck)
        {
            rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            ugrasKey = false;
        }
    }
    private void mozgas()
    {
        if (Input.GetKey(left))
        {
            horizontal = -1;
        }
        else if (Input.GetKey(right))
        {
            horizontal = 1;
        }
        else
        {
            horizontal = 0;
        }
    }
}
