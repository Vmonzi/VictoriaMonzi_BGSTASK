using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSeller : MonoBehaviour, IInventory
{
    public Inventory Inventory=> inventory;
    Inventory inventory;
    public List<ShopItem> itemsToSell;

    private void Awake()
    {
        for (int i = 0; i < itemsToSell.Count; i++)
        {
            inventory.AddItem(itemsToSell[i].item, itemsToSell[i].quantityItem);
        }
        //Clear memory
        itemsToSell.Clear();
    }
}


