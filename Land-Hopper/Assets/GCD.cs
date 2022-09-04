using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCD : MonoBehaviour
{
    public GameObject GC;
    public LayerMask Ground;
    bool IsGrounded;  
    void Start()
    {
        gameObject.transform.eulerAngles = new Vector3(
    gameObject.transform.eulerAngles.x - 90,
    gameObject.transform.eulerAngles.y,
    gameObject.transform.eulerAngles.z);
        IsGrounded = Physics.CheckSphere(GC.transform.position, 1f, Ground);
        if (!IsGrounded)
            Destroy(gameObject);
    }
}
