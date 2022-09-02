using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage()
    {
        health--;
    }

}
