using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponSlot : MonoBehaviour
{
    public Weapon currentWeapon;
    public UnityEvent OnAttackStart;
    public UnityEvent OnAttackFinish;
    private bool attackingEnabled;

    private void Start()
    {
        attackingEnabled = true;
        if (transform.childCount > 0)
        {
            setCurrentWeapon(transform.GetChild(0).GetComponent<Weapon>());
        }
    }

    public void equipWeapon(GameObject weaponPrefab)
    {
        //if (weaponPrefab.GetComponent<Weapon>() == null)
        //{
        //    return;
        //}

        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }

        if (weaponPrefab != null)
        {
            GameObject newWeaponObj = Instantiate(weaponPrefab, transform);
            setCurrentWeapon(newWeaponObj.GetComponent<Weapon>());
        }
        else
        {
            setCurrentWeapon(null);
        }

    }

    private void setCurrentWeapon(Weapon w)
    {
        currentWeapon = w;
        OnAttackStart.RemoveAllListeners();
        OnAttackFinish.RemoveAllListeners();

        if (w != null)
        {
            w.OnAttackStart.AddListener(delegate { OnAttackStart.Invoke(); });
            w.OnAttackFinish.AddListener(delegate { OnAttackFinish.Invoke(); });
        }
    }


    public void attackWithCurrentWeapon()
    {
        if (attackingEnabled && currentWeapon != null)
        {
            currentWeapon.attack();
        }
    }

    public void setAttackingEnabled(bool enabled)
    {
        attackingEnabled = enabled;
    }

}
