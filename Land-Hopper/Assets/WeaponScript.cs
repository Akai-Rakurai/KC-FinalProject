using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour
{
    //SO Ref
    public Vessel SO;

    bool Shooting, ReadyToShoot, Reloading;

    public Camera fpsCam;
    public Transform AttackPoint;
    public RaycastHit RayHit;
    public LayerMask WhatIsEnemy;

    public GameObject MuzzleFlash, BulletHoleGraphic, Bullet;
    GameObject FlashClone;
    public Text Ammo;

    public AmmoBar Bar;

    public AudioSource EmptyClip;
    public AudioSource GunShot;

    private void Start()
    {
        SO.BulletsLeft = SO.MagazineSize;
        Bar.SetMaxAmmo(SO.MagazineSize);
        Bar.SetAmmo(SO.BulletsLeft);
        Ammo.text = SO.BulletsLeft.ToString();
        ReadyToShoot = true;
    }
    private void MyInput()
    {
        if (SO.AllowHold) Shooting = Input.GetKey(KeyCode.Mouse0);
        else Shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && SO.BulletsLeft < SO.MagazineSize && !Reloading) Reload();

        if (ReadyToShoot && Shooting && !Reloading && SO.BulletsLeft > 0)
        {
            SO.BulletsShot = SO.BulletsPerTap;
            Shoot();
        }
        else if (SO.BulletsLeft == 0)
            EmptyClip.Play();
    }
    private void Reload()
    {
        Reloading = true;
        Ammo.text = "Reloading";
        Invoke("ReloadFinished", SO.ReloadTime);
    }
    private void ReloadFinished()
    {
        SO.BulletsLeft = SO.MagazineSize;
        Reloading = false;
        Bar.SetAmmo(SO.BulletsLeft);
        Ammo.text = SO.BulletsLeft.ToString();
    }
    private void ResetShoot()
    {
        ReadyToShoot = true;
        Bar.SetAmmo(SO.BulletsLeft);
        Ammo.text = SO.BulletsLeft.ToString();
    }
    private void Shoot()
    {
        ReadyToShoot = false;

        GunShot.Play();

        float x = Random.Range(-SO.Spread, SO.Spread);
        float y = Random.Range(-SO.Spread, SO.Spread);

        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(fpsCam.transform.position, direction, out RayHit, SO.Range, WhatIsEnemy))
        {
            if (RayHit.collider.CompareTag("Enemy"))
                //Note to self: Inbetween <> add the name of the enemy script
                RayHit.collider.GetComponent<EnemyAi2>().TakeDamage(SO.Damage);

            print(RayHit.collider.name);
        }
        
        FlashClone = Instantiate(MuzzleFlash, AttackPoint.position, Quaternion.identity, AttackPoint);
        Destroy(FlashClone, 1f);
        

        SO.BulletsLeft--;
        SO.BulletsShot--;

            Invoke("ResetShoot", SO.TimeBetweenShooting);

        if (SO.BulletsShot > 0 && SO.BulletsLeft > 0 && ReadyToShoot)
        Invoke("Shoot", SO.TimeBetweenShots);
    }
    private void FixedUpdate()
    {
        MyInput();
    }
}
