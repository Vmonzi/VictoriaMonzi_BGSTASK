using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private ItemDisplay itemPrototype;
    [SerializeField] private TMP_Text txtMoney;

    private List<ItemDisplay> _itemsUi = new();
    private Inventory _inventory;

    public event Action<ItemDisplay> OnItemClicked;

    public void Initialize()
    {
        itemPrototype.Show(false, force: true);
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
        var item = Instantiate(itemPrototype, itemPrototype.transform.parent);
        item.Show(true, force: true);
        item.itemButton.onClick.AddListener(() => OnItemClicked?.Invoke(item));
        _itemsUi.Add(item);
    }
}

