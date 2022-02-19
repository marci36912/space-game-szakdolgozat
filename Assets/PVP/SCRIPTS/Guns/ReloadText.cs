using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadText : MonoBehaviour
{
    private void Start()
    {
        Invoke("destroyMe", 1.5f);
    }

    private void destroyMe()
    {
        Destroy(this.gameObject);
    }    
}
