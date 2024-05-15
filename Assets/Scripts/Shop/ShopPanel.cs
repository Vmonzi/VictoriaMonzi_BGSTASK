using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : Panel
{
    IInventory _seller;
    IInventory _character;

    public ItemList sellerUi;
    public ItemList characterUi;

    private void Awake()
    {
        characterUi.Initialize();
    }
}
