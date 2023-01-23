using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vessel : ScriptableObject
{
    //Gun Stats + Score
    public int Score, Kills, NeededKills, MagazineSize, BulletsPerTap, BulletsLeft, Damage, BulletsShot, MaxHealth, Health;
    public float TimeBetweenShots, Spread, Range, ReloadTime, TimeBetweenShooting;
    public bool AllowHold;

    public void SetData()
    {
        Score = 0;
        Kills = 0;
        NeededKills = 10;
        Health = 100;
        MaxHealth = 100;
        NeededKills = 10;
        MagazineSize = 24;
        BulletsPerTap = 1;
        Damage = 10;
        TimeBetweenShooting = 0.1f;
        Spread = 0.5f;
        Range = 100;
        ReloadTime = 2;
        AllowHold = false;
    }

    
}
