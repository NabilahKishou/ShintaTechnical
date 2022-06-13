using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDatabase : MonoBehaviour
{
    public List<Weapon> weapons;

    public Weapon GetRandomWeapon()
    {
        int random = Random.Range(0, weapons.Count);
        return weapons[random];
    }
}
