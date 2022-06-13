using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour, IStorable
{
    public string weaponName;
    public int magazineCaps;
    public double weight;
    public float firePower;
    public string description;

    public Sprite weaponSprite;
    [SerializeField] protected WeaponType type;

    public void CloningValue(Weapon _weapon)
    {
        weaponName = _weapon.weaponName;
        magazineCaps = _weapon.magazineCaps;
        weight = _weapon.weight;
        firePower = _weapon.firePower;
        weaponSprite = _weapon.weaponSprite;
        type = _weapon.type;
        description = _weapon.description;

    }

    public void ClearProperty()
    {
        weaponName = "";
        magazineCaps = 0;
        weight = 0;
        firePower = 0;
        weaponSprite = null;
        description = "";
    }

}

public interface IStorable
{
    void CloningValue(Weapon _weapon);
    void ClearProperty();
}

public interface IShootable
{
    void TakeShoot();
}

public interface IThrowable
{
    void Throw();
}

public enum WeaponType
{
    gun,
    throwable
}

