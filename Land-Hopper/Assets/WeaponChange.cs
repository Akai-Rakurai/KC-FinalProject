using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public int SelectedWeapon = 0;
    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        int previousSelectedWeapon = SelectedWeapon;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(SelectedWeapon >= transform.childCount - 1)
                SelectedWeapon = 0;
            else
            SelectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SelectedWeapon <= 0)
                SelectedWeapon = transform.childCount - 1;
            else
                SelectedWeapon--;
        }
        if (previousSelectedWeapon != SelectedWeapon)
            SelectWeapon();
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == SelectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
