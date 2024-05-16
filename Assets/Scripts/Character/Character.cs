using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IInventoryOwner
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    [SerializeField] private float _speed;
    [SerializeField] private int initialMoney = 50;
    private Inventory _inventory;

    public Inventory Inventory => _inventory;

    private void Awake()
    {
        _inventory = new Inventory(initialMoney);
    }

    private void Start()
    {
        GameManager.Instance.UIManager.ShopPanel.SetBuyerInventory(this);
        GameManager.Instance.UIManager.InventoryPanel.SetCharacterInventory(this);
    }

    private void Update()
    {
        Movement(_speed);

        if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.CanShop)
            GameManager.Instance.UIManager.ShowShop(!GameManager.Instance.UIManager.ShopPanel.Shown);

        if (Input.GetKeyDown(KeyCode.I))
            GameManager.Instance.UIManager.ShowInventory(!GameManager.Instance.UIManager.InventoryPanel.Shown);
    }

    public void Movement(float speed)
    {
        float moveX = Input.GetAxis(HORIZONTAL);
        float moveY = Input.GetAxis(VERTICAL);

        Vector3 move = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;

        transform.position += move;
    }
}
