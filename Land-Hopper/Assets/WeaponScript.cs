using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    //Gun Stats
    public int Damage;
    public float TimeBetweenShots, Spread, Range, ReloadTime, TimeBetweenShooting;
    public int MagazineSize, BulletsPerTap;
    public bool AllowHold;
    int BulletsShot, BulletsLeft;

    bool Shooting, ReadyToShoot, Reloading;

    public Camera fpsCam;
    public Transform AttackPoint;
    public RaycastHit RayHit;
    public LayerMask WhatIsEnemy;

    public GameObject MuzzleFlash, BulletHoleGraphic;

    private void Start()
    {
        BulletsLeft = MagazineSize;
        ReadyToShoot = true;
    }
    private void MyInput()
    {
        if (AllowHold) Shooting = Input.GetKey(KeyCode.Mouse0);
        else Shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && BulletsLeft < MagazineSize && !Reloading) Reload();

        if (ReadyToShoot && Shooting && !Reloading && BulletsLeft > 0)
        {
            BulletsShot = BulletsPerTap;
            Shoot();
        }
    }
    private void Reload()
    {
        Reloading = true;
        Invoke("ReloadFinished", ReloadTime);
    }
    private void ReloadFinished()
    {
        BulletsLeft = MagazineSize;
        Reloading = false;
    }
    private void ResetShoot()
    {
        ReadyToShoot = true;
    }
    private void Shoot()
    {
        ReadyToShoot = false;

        float x = Random.Range(-Spread, Spread);
        float y = Random.Range(-Spread, Spread);

        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(fpsCam.transform.position, direction, out RayHit, Range, WhatIsEnemy))
        {
            print(RayHit.collider.name);


        }

        Instantiate(MuzzleFlash, AttackPoint.position, Quaternion.identity);

        BulletsLeft--;
        BulletsShot--;

        Invoke("ResetShoot", TimeBetweenShooting);

        if(BulletsShot > 0 && BulletsLeft > 0 && ReadyToShoot)
        Invoke("Shoot", TimeBetweenShots);
    }
    private void FixedUpdate()
    {
        MyInput();
    }
}
