public class ShopPanel : Panel
{
    private IInventoryOwner _seller;
    private IInventoryOwner _character;

    public InventoryDisplay sellerUi;
    public InventoryDisplay characterUi;

    protected override void Awake()
    {
        base.Awake();

        characterUi.Initialize();
        sellerUi.Initialize();

        sellerUi.OnItemClicked += BuyItem;
        characterUi.OnItemClicked += SellItem;
    }

    public void SetSellerInventory(IInventoryOwner seller)
    {
        _seller = seller;
        sellerUi.SetInventory(seller.Inventory);
    }

    public void SetBuyerInventory(IInventoryOwner buyer)
    {
        _character = buyer;
        characterUi.SetInventory(buyer.Inventory);
    }

    public override void Refresh()
    {
        characterUi.Refresh();
        sellerUi.Refresh();
    }

    public void BuyItem(ItemDisplay item)
    {
        //Function proposed by the purchase in case it is possible
        if (_character == null || _seller == null) return;

        int amount = 1; //HARDCODED FOR NOW

        if (!_seller.Inventory.CanRemove(item.itemDataSO, amount)) return;
        if (!_character.Inventory.CanBuyThis(item.itemDataSO.cost, amount)) return;

        var money = item.itemDataSO.cost * amount;
        _character.Inventory.RemoveMoney(money);
        _seller.Inventory.AddMoney(money);

        _character.Inventory.AddItem(item.itemDataSO, amount);
        _seller.Inventory.RemoveItem(item.itemDataSO, amount);

        Refresh();
    }

    public void SellItem(ItemDisplay item)
    {
        //Function proposed by the sale in case it is possible and there is stock
        if (_character == null || _seller == null) return;

        int amount = 1; //HARDCODED FOR NOW

        if (!_character.Inventory.CanRemove(item.itemDataSO, amount)) return;
        if (!_seller.Inventory.CanBuyThis(item.itemDataSO.cost, amount)) return;

        var money = item.itemDataSO.cost * amount;
        _seller.Inventory.RemoveMoney(money);
        _character.Inventory.AddMoney(money);

        _character.Inventory.RemoveItem(item.itemDataSO, amount);
        _seller.Inventory.AddItem(item.itemDataSO, amount);

        Refresh();
    }
}

