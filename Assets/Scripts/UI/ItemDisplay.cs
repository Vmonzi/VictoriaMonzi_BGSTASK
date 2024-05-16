using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemDisplay : MonoBehaviour
{
    public Button itemButton;
    public Image imgIcon;

    private bool shown;

    public Item_SO itemDataSO { get; set; }

    private void Awake()
    {

    }

    public void SetItem(Item_SO item, int quantity)
    {
        itemDataSO = item;
        imgIcon.sprite = item.icon;
    }

    public void Show(bool visible, bool force = false)
    {
        if (shown == visible && !force) return;
        shown = visible;

        gameObject.SetActive(shown);
    }
}

