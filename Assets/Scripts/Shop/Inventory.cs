using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<IInventory, int> _inventory = new();

    public void AddItem(IInventory item, int quantity)
    {
        if (_inventory.ContainsKey(item))
        {
            _inventory[item] += quantity;
        }
    }
    public bool CanRemove(IInventory item, int quantity)
    {
        return true;
    }
    public void RemoveItem(IInventory item, int quantity)
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
    public Dictionary<IInventory, int> GetInventory()
    {
        return _inventory;
    }
}
