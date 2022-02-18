using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mozgas : MonoBehaviour
{
    [SerializeField] private float ugras = 5f;
    [SerializeField] private float sebesseg = 5f;
    [SerializeField] private Transform fold;
    [SerializeField] private LayerMask foldLayer;
    private Animator anim;
    private Rigidbody2D player;
    private float atmero = 0.1f;
    private float poz;
    private bool ugrikE = false;
    private bool ugrikEFold;
    //private bool jobbra = true;


    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ugrikE = true;            
        }
        poz = Input.GetAxis("Horizontal");

        anim.SetBool("UgrikEe", ugrikE);
        anim.SetFloat("Futas", Mathf.Abs(poz));
    }

    private void FixedUpdate()
    {
        #region ugras

        ugrikEFold = Physics2D.OverlapCircle(fold.position, atmero, foldLayer);


        if (ugrikE && ugrikEFold)
        {
            player.AddForce(new Vector2(0, ugras), ForceMode2D.Impulse);           
            ugrikE = false;
        }
        
        #endregion
        player.velocity = new Vector2(poz * sebesseg, player.velocity.y);
    }
}
