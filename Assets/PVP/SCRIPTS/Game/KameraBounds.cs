using System.Linq;
using UnityEngine;

public class KameraBounds : MonoBehaviour
{
    [SerializeField] private Transform[] player;
    [SerializeField] private Vector3 tav;

    private Vector3 tmp;

    private Camera main;

    private float min = 2.6f;
    private float max = 11f;

    private void Start()
    {
        main = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        player = player.Where(x => x != null).ToArray();
        kameraSize();
        kameraZoom();
    }

    private void kameraZoom()
    {
        float zoom = Mathf.Lerp(min, max, getTav() / 10);
        main.orthographicSize = Mathf.Lerp(main.orthographicSize, zoom, Time.deltaTime);
    }
    private void kameraSize()
    {
        Vector3 kozep = getKozep();
        Vector3 ujKozep = kozep + tav;

        transform.position = Vector3.SmoothDamp(transform.position, ujKozep, ref tmp, 0.25f);
    }
    private float getTav()
    {
        if (player.Length == 0)
        {
            return 0;
        }
        Bounds kozep = new Bounds(player[0].position, Vector3.zero);

        for (int i = 0; i < player.Length; i++)
        {
            kozep.Encapsulate(player[i].position);
        }

        return kozep.size.x;
    }
    private Vector3 getKozep()
    {
        if (player.Length == 0)
        {
            return new Vector3(0,0);
        }
        else if (player.Length == 1)
        {
            return player[0].position;
        }
        
        Bounds kozep = new Bounds(player[0].position, Vector3.zero);

        for (int i = 0; i < player.Length; i++)
        {
            kozep.Encapsulate(player[i].position);
        }

        return kozep.center;
    }
}
