using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckEquippedWeapon : MonoBehaviour
{
    public string weaponName;
    public UnityEvent WeaponWasEquipped;

    public void checkWeapon()
    {
        WeaponSlot slot = Player.instance.GetComponentInChildren<WeaponSlot>();
        
        if (slot != null && slot.currentWeapon != null && slot.currentWeapon.weaponName.Equals(weaponName))
        {
            WeaponWasEquipped.Invoke();
        }
    }
}
