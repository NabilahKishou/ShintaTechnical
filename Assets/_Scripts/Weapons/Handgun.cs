using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Weapon, IShootable
{
    public void TakeShoot()
    {
        HandgunBehaviour();
    }

    private void HandgunBehaviour()
    {
        print(this.weaponName + " shootingBehaviour");
    }
}
