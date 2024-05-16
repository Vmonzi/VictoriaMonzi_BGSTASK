using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IInventoryOwner
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    [SerializeField] private float _speed;
    [SerializeField] private int _initialMoney = 50;
    private Inventory _inventory;

    public Inventory Inventory => _inventory;

    private void Awake()
    {
        _inventory = new Inventory(_initialMoney);
    }

    private void Start()
    {
        GameManager.Instance.UIManager.ShopPanel.SetBuyerInventory(this);
        GameManager.Instance.UIManager.InventoryPanel.SetCharacterInventory(this);
    }

    private void Update()
    {
        Movement(_speed);
        //pressing the E key and being in the purchasing area we access the shop panel
        if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.CanShop)
            GameManager.Instance.UIManager.ShowShop(!GameManager.Instance.UIManager.ShopPanel.Shown);
        //pressing the I key we access the inventory panel
        if (Input.GetKeyDown(KeyCode.I))
            GameManager.Instance.UIManager.ShowInventory(!GameManager.Instance.UIManager.InventoryPanel.Shown);
    }

    //movement
    public void Movement(float speed)
    {
        float moveX = Input.GetAxis(HORIZONTAL);
        float moveY = Input.GetAxis(VERTICAL);

        Vector3 move = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;

        transform.position += move;
    }
}
