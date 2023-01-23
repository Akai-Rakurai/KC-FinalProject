using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatling : MonoBehaviour
{
    public Vessel SO;
    public Animator Anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SO.AllowHold = true;
            Anim.SetTrigger("Item");
            Destroy(gameObject);
        }
    }
}
