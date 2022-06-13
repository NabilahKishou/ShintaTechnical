using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class WeaponUI : MonoBehaviour, IWeaponUIHandler, IPointerEnterHandler, IPointerExitHandler {
    private Image spriteImage;

    private Weapon weapon;

    public static event Action<Weapon> OnMouseHover;
    public static event Action OnMouseExit;

    private void OnEnable()
    {
        UpdateWeaponUI();
    }

    private Weapon FindActiveWeaponScript()
    {
        Weapon[] weapons = gameObject.GetComponents<Weapon>();
        print("LENGTH: " + weapons.Length);

        if (weapons.Length == 1) return weapons[0];

        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].weaponName == "") continue;
            return weapons[i];
        }

        return weapon;
    }

    public void UpdateUI(Weapon _weapon)
    {
        weapon = _weapon;
        ImplementSprite(weapon.weaponSprite);
    }

    protected void ImplementSprite(Sprite spriteImage)
    {
        Image spriteImg = gameObject.GetComponentInChildren<Image>();
        spriteImg.sprite = spriteImage;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print(GetComponent<Weapon>().weaponName);
        if (weapon.weaponName == "") return;

        OnMouseHover?.Invoke(weapon);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnMouseExit?.Invoke();
    }

    public void UpdateWeaponUI()
    {
        weapon = FindActiveWeaponScript();
        spriteImage = gameObject.GetComponentInChildren<Image>();

        if (weapon == null) return;

        print("WEAPONUI: " + weapon.isActiveAndEnabled);
        ImplementSprite(weapon.weaponSprite);
    }
}

public interface IWeaponUIHandler
{
    void UpdateWeaponUI();
}
