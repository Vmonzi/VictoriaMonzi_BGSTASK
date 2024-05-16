using System.Collections.Generic;

public class Inventory
{
    private Dictionary<Item_SO, int> _inventory = new();
    private int money;

    public int Money => money;
    public bool HasIlimitedMoney { get; private set; }

    public Inventory(int money = -1)
    {
        this.money = money;
        HasIlimitedMoney = money == -1;
    }

    public bool CanBuyThis(int quantity, int price)
    {
        if (HasIlimitedMoney) return true;
        return quantity * price <= money;
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void AddItem(Item_SO item, int quantity)
    {
        if (_inventory.ContainsKey(item))
            _inventory[item] += quantity;
        else
            _inventory.Add(item, quantity);
    }

    public bool CanRemove(Item_SO item, int quantity)
    {
        //TODO verify has enought of that item
        return true;
    }

    public void RemoveItem(Item_SO item, int quantity)
    {
        if (!CanRemove(item, quantity)) return;

        if (_inventory.ContainsKey(item))
        {
            _inventory[item] -= quantity;

            // Remove if there are no more items
            if (_inventory[item] <= 0)
                _inventory.Remove(item);

        }
    }
    public Dictionary<Item_SO, int> GetInventory()
    {
        return _inventory;
    }
}

