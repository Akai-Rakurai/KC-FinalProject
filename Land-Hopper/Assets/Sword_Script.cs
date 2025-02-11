using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword_Script : MonoBehaviour
{
    public Vessel SO;

    public PlayerMovement PM;
    public int Damage;
    private Animator Animator;
    public Text HealthAmount;

    public HeaalthBar Bar;
    void Start()
    {
        PM = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
        Animator = GetComponent<Animator>();
    }
    public void SwordAttack()
    {
        Animator.SetTrigger("Base_Attack");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SO.Health -= Damage;

            Bar.SetHealth(SO.Health);
            HealthAmount.text = SO.Health.ToString();
        }
    }
}
