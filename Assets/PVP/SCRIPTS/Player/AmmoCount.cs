using UnityEngine;
using TMPro;

public class AmmoCount : MonoBehaviour
{
    private TextMeshPro ammo;
    Shooting st;

    private void Start()
    {
        st = GetComponentInParent<Shooting>();
        ammo = GetComponent<TextMeshPro>();
    }

    private void LateUpdate()
    {
        ammo.text = new string('|', st.ammo);
    }
}
