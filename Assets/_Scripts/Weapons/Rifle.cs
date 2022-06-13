using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon, IShootable
{
    public void TakeShoot()
    {
        RifleBehaviour();
    }

    private void RifleBehaviour()
    {
        print(this.weaponName + " shootingBehaviour");
    }
}
