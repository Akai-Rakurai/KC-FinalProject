using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;

    public Image fill;

    public void SetMaxAmmo(int Ammo)
    {
        slider.maxValue = Ammo;
        slider.value = Ammo;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetAmmo(int Ammo)
    {
        slider.value = Ammo;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
