using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Inventory : MonoBehaviour
{
    Dictionary<IColection, int> _inventory = new();

    public void AddItem(IColection item, int quantity)
    {
        if (_inventory.ContainsKey(item)) _inventory[item] += quantity;
    }
    public bool CanRemove(IColection item, int quantity)
    {
        return true;
    }
    public void RemoveItem(IColection item, int quantity)
    {
        if (!CanRemove(item, quantity)) return;
        //feedback

        if (_inventory.ContainsKey(item))
        {
            _inventory[item] -= quantity;

            // Elimina el ítem si no hay mas
            if (_inventory[item] <= 0) _inventory.Remove(item);

        }
    }
    public Dictionary<IColection, int> GetInventory()
    {
        return _inventory;
    }
}
