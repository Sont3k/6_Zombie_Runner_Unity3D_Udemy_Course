using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);
        
        return ammoSlot.ammoAmount;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);
        ammoSlot.ammoAmount++;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);
        ammoSlot.ammoAmount--;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (var slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }

        return null;
    }
}
