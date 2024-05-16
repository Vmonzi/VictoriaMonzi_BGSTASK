using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class InteractionWidget : Panel
{
    [SerializeField] private TMP_Text txtInteraction;

    public override void Refresh() { }

    public void SetText(string interaction)
    {
        txtInteraction.SetText(interaction);
    }
}

