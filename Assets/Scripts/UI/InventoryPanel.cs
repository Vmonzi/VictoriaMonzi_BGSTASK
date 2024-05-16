using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : Panel
{
    private IInventoryOwner _character;
    public InventoryDisplay characterUi;

    protected override void Awake()
    {
        base.Awake();
        characterUi.Initialize();
        characterUi.OnItemClicked += EquipItem;
    }

    public void SetCharacterInventory(IInventoryOwner character)
    {
        _character = character;
        characterUi.SetInventory(character.Inventory);
    }

    public override void Refresh()
    {
        characterUi.Refresh();
    }

    public void EquipItem(ItemDisplay item)
    {
        if (_character == null) return;
        //TODO implement equip system

        Debug.Log("Player equiped: " + item.itemDataSO.objectName);
    }
}

