using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Script : MonoBehaviour
{
    public PlayerMovement PM;
    public int Damage;
    private Animator Animator;
    void Start()
    {
        PM = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void SwordAttack()
    {
        Animator.SetTrigger("Base_Attack");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PM.Health -= Damage;
        }
    }
}
