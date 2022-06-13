using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
    [SerializeField]
    private TMP_Text tooltipText;

	void Start () {
        CloseTooltip();

        WeaponUI.OnMouseExit += CloseTooltip;
        WeaponUI.OnMouseHover += OpenToolTip;
	}

    private void OnDestroy()
    {
        WeaponUI.OnMouseExit -= CloseTooltip;
        WeaponUI.OnMouseHover -= OpenToolTip;
    }

    private void CloseTooltip()
    {
        this.gameObject.SetActive(false);
    }

    private void OpenToolTip(Weapon _weapon)
    {
        string weaponStats = "";
        weaponStats += "Magazine Capacity: " + _weapon.magazineCaps + "\n";
        weaponStats += "Firepower: " + _weapon.firePower + "\n";
        weaponStats += "Weight: " + _weapon.weight;

        string tooltip = string.Format("<b>{0}</b>\n{1}\n<b>{2}</b>", _weapon.weaponName, _weapon.description, weaponStats);
        tooltipText.text = tooltip;

        print("TOOLTIP: " + tooltip);
        gameObject.SetActive(true);
    }
}
