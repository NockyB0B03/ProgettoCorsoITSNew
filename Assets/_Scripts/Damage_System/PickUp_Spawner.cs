using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

[Flags]
public enum PickUpSpawnType
{
    None = 0,
    HEAL = 1,
    WEAPON = 2,
    AMMO = 3,
}

public class PickUp_Spawner : MonoBehaviour
{
    [SerializeField] PickUp healPicklUp;
    [SerializeField] PickUp weaponPickUp;
    [SerializeField] PickUp bulletPickUp;

    [SerializeField] PickUpSpawnType spawnType;
    [SerializeField] List<WeaponData> elegibleWeapons = new();

    [SerializeField] bool startsWithPickUp;
    [SerializeField] float cooldown;

    GameObject currentPickUp;

    private void Awake()
    {
        if(startsWithPickUp)
        {
            SpawnPickUp();
            return;
        }
        StartCoroutine(WaitCooldown(cooldown));

    }




}
