using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poker_Card : MonoBehaviour
{
    public Vessel SO;
    public Animator Anim;
    public Animator Anim2;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            int Val = Random.Range(0, 7);
            int Val2 = Random.Range(0, 7);
            //for buff
            if(Val == 1)
                SO.Damage += 2;
            if(Val == 2)
                SO.TimeBetweenShooting -= 2;
            if (Val == 3)
                SO.Range += 50;
            if (Val == 4)
                SO.ReloadTime -= 0.2f;
            if (Val == 5)
                SO.MagazineSize += 4;
            if (Val == 6)
                SO.BulletsPerTap += 1;

            //for debuff
            if (Val2 == 1)
                SO.Damage -= 2;
            if (Val2 == 2)
                SO.TimeBetweenShooting += 2;
            if (Val2 == 3)
                SO.Range -= 50;
            if (Val2 == 4)
                SO.ReloadTime += 0.2f;
            if (Val2 == 5)
                SO.MagazineSize -= 4;
            if (Val2 == 6)
                SO.BulletsPerTap -= 1;

            Anim.SetTrigger("Item");
            Anim.SetTrigger("Item");
            Destroy(gameObject);

        }
    }
}
//Dmg, ShotSpeed, Range, ReloadTime, MagSize, BPT