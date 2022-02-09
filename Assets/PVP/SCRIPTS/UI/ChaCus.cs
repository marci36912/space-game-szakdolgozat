using UnityEngine;

public class ChaCus : MonoBehaviour
{
    [Header("sprites")]
    [SerializeField] private Sprite[] hat;
    [SerializeField] private Sprite[] face;
    [SerializeField] private Color[] p1Colors;
    [SerializeField] private Color[] p2Colors;

    [Header("P1")]
    [SerializeField] private SpriteRenderer p1Hat;
    [SerializeField] private SpriteRenderer p1Face;
    [SerializeField] private SpriteRenderer p1;

    private int p1hatActive;
    private int p1FaceActive;
    private int p1ColActive;

    [Header("P2")]
    [SerializeField] private SpriteRenderer p2Hat;
    [SerializeField] private SpriteRenderer p2Face;
    [SerializeField] private SpriteRenderer p2;

    private int p2hatActive;
    private int p2FaceActive;
    private int p2ColActive;

    private void Start()
    {
        Time.timeScale = 0;

        p1hatActive = 0;
        p1FaceActive = 0;
        p1ColActive = 0;

        p2hatActive = 0;
        p2FaceActive = 0;
        p2ColActive = 0;

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
