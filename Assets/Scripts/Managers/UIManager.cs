using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ShopPanel _shopPanel;
    [SerializeField] private InventoryPanel _inventoryPanel;
    [SerializeField] private InteractionWidget _interactionWidget;
    private bool wasInteractionShowing;

    public ShopPanel ShopPanel => _shopPanel;
    public InventoryPanel InventoryPanel => _inventoryPanel;
    public InteractionWidget InteractionWidget => _interactionWidget;

    public void ShowShop(bool show)
    {
        if (show)
        {
            wasInteractionShowing = InteractionWidget.Shown;

            if (wasInteractionShowing)
                ShowInteractionWidget(false);

            ShopPanel.Open();
        }
        else
        {
            ShopPanel.Close();

            if (wasInteractionShowing)
                ShowInteractionWidget(wasInteractionShowing);

            wasInteractionShowing = InteractionWidget.Shown;
        }
    }

    public void ShowInteractionWidget(bool show)
    {
        if (show)
            InteractionWidget.Open();
        else
            InteractionWidget.Close();
    }

    public void ShowInventory(bool show)
    {
        if (ShopPanel.Shown) return;

        if (show)
            InventoryPanel.Open();
        else
            InventoryPanel.Close();

    }
}

