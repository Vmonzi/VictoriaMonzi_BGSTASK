using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public ItemUI itemPrototype; //button
    List<ItemUI> _itemsUi;
    public event Action<ItemUI> OnItemClicked;

    IInventory _inventoryOwner;

    public void Initialize()
    {
        _itemsUi = new();
        itemPrototype.Show(false, force: true);
    }

    public void SetInventory()
    {

    }

    public void Refresh()
    {
    }

    private void CreateItem()
    {
    }
}
