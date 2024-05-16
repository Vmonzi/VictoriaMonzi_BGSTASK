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

    [SerializeField] private string interactionName = "Shop";
    [SerializeField] private List<ShopItem> itemsToSell;

    private Inventory inventory;

    public Inventory Inventory => inventory;


    private void Awake()
    {
        inventory = new();

        for (int i = 0; i < itemsToSell.Count; i++)
            inventory.AddItem(itemsToSell[i].item, itemsToSell[i].quantity);

        //Clear memory
        itemsToSell.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.UIManager.InteractionWidget.SetText(interactionName);
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





