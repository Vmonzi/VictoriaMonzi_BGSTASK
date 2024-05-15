using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Seller : MonoBehaviour, IColection
{
    public Base_Inventory _inventoryColection => throw new System.NotImplementedException();
    Base_Inventory _inventorySeller;
    public List<ShopItem> itemsToSell;
    public Base_Inventory _inventory => _inventorySeller;

    private void Awake()
    {
        for (int i = 0; i < itemsToSell.Count; i++) _inventory.AddItem(itemsToSell[i].item, itemsToSell[i].quantityItem);

        //Clear memory
        itemsToSell.Clear();
    }
}


