using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public GameObject weaponPrefab;

    public void equip()
    {
        Player.instance.GetComponentInChildren<WeaponSlot>().equipWeapon(weaponPrefab);
    }
}
