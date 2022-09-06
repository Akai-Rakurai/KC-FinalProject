using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Sword : MonoBehaviour
{
    public int Damage;
    private Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Animator.SetTrigger("Attack");
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyAi2>().TakeDamage(Damage);
            print(other.gameObject.tag);
            print(other.gameObject);
            
        }

    }
}
