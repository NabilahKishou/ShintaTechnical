using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private ObjectPool weaponPooler;
    [SerializeField]
    private WeaponDatabase weaponDatabase;

    private List<IStorable> weaponList = new List<IStorable>();

    [SerializeField]
    private Button showAllBtn, handgunBtn, rifleBtn, grenadeBtn;

    private void Awake()
    {
        handgunBtn.onClick.AddListener(() => { FindAllWeaponsOfType<Handgun>(); showAllBtn.interactable = true; });
        rifleBtn.onClick.AddListener(() => { FindAllWeaponsOfType<Rifle>(); showAllBtn.interactable = true; });
        grenadeBtn.onClick.AddListener(() => { FindAllWeaponsOfType<Grenade>(); showAllBtn.interactable = true; });
        showAllBtn.interactable = false;
    }

    private bool isShowAll = false;
    public void ShowAllStoreable()
    {
        if (!isShowAll) return;

        for (int i = 0; i < weaponPooler.pooledObjects.Count; i++)
        {
            weaponPooler.pooledObjects[i].SetActive(true);
        }

        showAllBtn.interactable = false;
    }

    public void GenerateInventory()
    {
        ClearWeaponList();

        for (int i = 0; i < weaponPooler.amountToPool; i++)
        {
            GetWeapon();
        }

        isShowAll = true;
        showAllBtn.interactable = false;
    }

    private void ClearWeaponList()
    {
        if (weaponList.Count == 0) return;

        weaponList = new List<IStorable>();

        IStorable[] iStoreables;

        for (int i = 0; i < weaponPooler.pooledObjects.Count; i++)
        {
            iStoreables = weaponPooler.pooledObjects[i].GetComponents<IStorable>();
            print("countStorables: " + iStoreables.Length);

            foreach(IStorable able in iStoreables)
            {
                able.ClearProperty();
            }
            weaponPooler.pooledObjects[i].SetActive(false);
        }
    }

    private void GetWeapon()
    {
        Weapon weaponFromDB = weaponDatabase.GetRandomWeapon();
        var weaponObj = AddGenericWeaponToObjectpool(weaponFromDB);
        IStorable weapon = weaponObj.GetComponent(weaponObj.GetType()) as Weapon;
        
        weaponList.Add(weapon);
        weapon.CloningValue(weaponFromDB);

        IWeaponUIHandler weaponUI = weaponPooler.GetPooledObject().GetComponent<IWeaponUIHandler>();
        weaponUI.UpdateWeaponUI();

        weaponObj.gameObject.SetActive(true);
    }

    private T AddGenericWeaponToObjectpool<T>(T weaponParam) where T : Weapon
    {
        var weaponFromPool = weaponPooler.GetPooledObject();
        Type scriptType = weaponParam.GetType();

        T script = weaponFromPool.GetComponent(scriptType) as T;
        if (script != null) return script;

        T weaponScript = weaponFromPool.AddComponent(scriptType) as T;

        return weaponScript;
    }

    private void SetWeaponsUnactive()
    {
        for(int i = 0; i < weaponPooler.amountToPool; i++)
        {
            weaponPooler.pooledObjects[i].SetActive(false);
        }
    }

    public List<T> FindAllWeaponsOfType<T>() where T : Weapon
    {
        SetWeaponsUnactive();

        List<T> listOfWeapons = new List<T>();

        foreach(Weapon weapon in weaponList)
        {
            if(weapon is T)
            {
                listOfWeapons.Add(weapon as T);
                weapon.gameObject.SetActive(true);
            }

        }

        return listOfWeapons;
    }
}
