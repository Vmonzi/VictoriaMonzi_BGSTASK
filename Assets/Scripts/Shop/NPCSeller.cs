using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSeller : MonoBehaviour, IInventoryOwner
{
    [Serializable]
    public class ShopItem
    {
        public Item_SO item;
        public int quantity;
    }

    [SerializeField] private string _interactionName = "Shop";
    [SerializeField] private List<ShopItem> _itemsToSell;

    private Inventory _inventory;

    public Inventory Inventory => _inventory;


    private void Awake()
    {
        _inventory = new();

        for (int i = 0; i < _itemsToSell.Count; i++)
            _inventory.AddItem(_itemsToSell[i].item, _itemsToSell[i].quantity);

        //Clear memory
        _itemsToSell.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.UIManager.InteractionWidget.SetText(_interactionName);
        GameManager.Instance.UIManager.ShowInteractionWidget(true);
        GameManager.Instance.CanShop = true;
        GameManager.Instance.UIManager.ShopPanel.SetSellerInventory(this);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.Instance.CanShop = false;
        GameManager.Instance.UIManager.ShowInteractionWidget(false);
    }
}





