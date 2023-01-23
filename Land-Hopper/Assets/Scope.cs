using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Vessel SO;
    public Animator Anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SO.Range *= 1.5f;
            Anim.SetTrigger("Item");
            Destroy(gameObject);
        }
    }
}
