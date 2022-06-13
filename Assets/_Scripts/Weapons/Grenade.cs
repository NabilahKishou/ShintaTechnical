using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grenade : Weapon, IThrowable
{
    public void Throw()
    {
        GrenadeBehaviour();
    }

    private void GrenadeBehaviour()
    {
        print(weaponName + " Throw Behaviour");
    }
}