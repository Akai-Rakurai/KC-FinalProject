using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mag : MonoBehaviour
{
    public Vessel SO;
    public Animator Anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SO.MagazineSize += 12;
            Anim.SetTrigger("Item");
            Destroy(gameObject);
        }
    }
}
