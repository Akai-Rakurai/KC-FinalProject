using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour
{
    //Gun Stats
    public int Damage;
    public float TimeBetweenShots, Spread, Range, ReloadTime, TimeBetweenShooting;
    public int MagazineSize, BulletsPerTap, BulletsLeft;
    public bool AllowHold;
    int BulletsShot;

    bool Shooting, ReadyToShoot, Reloading;

    public Camera fpsCam;
    public Transform AttackPoint;
    public RaycastHit RayHit;
    public LayerMask WhatIsEnemy;

    public GameObject MuzzleFlash, BulletHoleGraphic, Bullet;
    GameObject FlashClone;
    public Text Ammo;

    public AmmoBar Bar;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Bullets") <= 0)
        {
            BulletsLeft = MagazineSize;
        }
        else if (PlayerPrefs.GetInt("Bullets") > 0)
        {
            BulletsLeft = PlayerPrefs.GetInt("Bullets");
        }
        
        Bar.SetMaxAmmo(MagazineSize);
        Bar.SetAmmo(BulletsLeft);
        Ammo.text = BulletsLeft.ToString();
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
        Ammo.text = "Reloading";
        Invoke("ReloadFinished", ReloadTime);
    }
    private void ReloadFinished()
    {
        BulletsLeft = MagazineSize;
        Reloading = false;
        Bar.SetAmmo(BulletsLeft);
        Ammo.text = BulletsLeft.ToString();
    }
    private void ResetShoot()
    {
        ReadyToShoot = true;
        Bar.SetAmmo(BulletsLeft);
        Ammo.text = BulletsLeft.ToString();
    }
    private void Shoot()
    {
        ReadyToShoot = false;

        float x = Random.Range(-Spread, Spread);
        float y = Random.Range(-Spread, Spread);

        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(fpsCam.transform.position, direction, out RayHit, Range, WhatIsEnemy))
        {
            if (RayHit.collider.CompareTag("Enemy"))
                //Note to self: Inbetween <> add the name of the enemy script
                RayHit.collider.GetComponent<EnemyAi2>().TakeDamage(Damage);

            print(RayHit.collider.name);
        }
        
        FlashClone = Instantiate(MuzzleFlash, AttackPoint.position, Quaternion.identity, AttackPoint);
        Destroy(FlashClone, 1f);
        

        BulletsLeft--;
        BulletsShot--;

            Invoke("ResetShoot", TimeBetweenShooting);

        if (BulletsShot > 0 && BulletsLeft > 0 && ReadyToShoot)
        Invoke("Shoot", TimeBetweenShots);
    }
    private void FixedUpdate()
    {
        MyInput();
    }
}
