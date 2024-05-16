using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private ItemDisplay _itemPrototype;
    [SerializeField] private TMP_Text txtMoney;

    private List<ItemDisplay> _itemsUi = new();
    private Inventory _inventory;

    public event Action<ItemDisplay> OnItemClicked;

    public void Initialize()
    {
        _itemPrototype.Show(false, force: true);
    }

    public void SetInventory(Inventory newInventory)
    {
        _inventory = newInventory;
        txtMoney.gameObject.SetActive(!_inventory.HasIlimitedMoney);
        Refresh();
    }

    public void Refresh()
    {
        var count = 0;
        foreach (var item in _inventory.GetInventory())
        {
            //if (item.Value == 0) continue;
            if (count >= _itemsUi.Count) 
                CreateItem();

            _itemsUi[count].SetItem(item.Key, item.Value);
            _itemsUi[count].Show(true);
            count++;
        }

        for (int i = count; i < _itemsUi.Count; i++)
            _itemsUi[i].Show(false);

        if(!_inventory.HasIlimitedMoney)
            txtMoney.SetText(_inventory.Money.ToString());
    }


    private void CreateItem()
    {
        //Create the item. instantiate it in the place of the prototype
        //activate its visualization in Show and invoke the item from the button
        var item = Instantiate(_itemPrototype, _itemPrototype.transform.parent);
        item.Show(true, force: true);
        item.itemButton.onClick.AddListener(() => OnItemClicked?.Invoke(item));
        _itemsUi.Add(item);
    }
}

