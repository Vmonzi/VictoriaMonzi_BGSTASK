using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IInventory
{
    [SerializeField] float _speed;

    public Inventory Inventory => inventoryCharacter;
    Inventory inventoryCharacter;
    private void Update()
    {
        Movement(_speed);
    }


    public void Movement(float speed)

    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;

        transform.position += move;
    }
}
