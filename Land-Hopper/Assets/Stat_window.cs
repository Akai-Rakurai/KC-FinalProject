using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat_window : MonoBehaviour
{
    public Animator Anima;

    public Vessel SO;

    public Text Dmg;
    public Text Magsize;
    public Text ReSpeed;
    public Text Delay;
    public Text Burst;
    public Text Range;

    public bool Shown;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !Shown)
        {
            Shown = true;
            print("Success");
            Anima.SetTrigger("Show");
        }
        else if(Input.GetKeyDown(KeyCode.P) && Shown)
        {
            Shown = false;
            Anima.SetTrigger("Hide");
            print("Success1");
        }
        if(Shown)
        {
            StatChange();
        }
    }
    public void StatChange()
    {
        Dmg.text = SO.Damage.ToString();
        Magsize.text = SO.MagazineSize.ToString();
        ReSpeed.text = SO.ReloadTime.ToString();
        Delay.text = SO.TimeBetweenShooting.ToString();
        Burst.text = SO.BulletsPerTap.ToString();
        Range.text = SO.Range.ToString();
    }


}
