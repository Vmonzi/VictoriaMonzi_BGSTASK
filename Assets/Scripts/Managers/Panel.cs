using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public bool Shown { get; private set; }

    public void Open()
    {
        if (Shown) return;
    }

    public void Close()
    {

    }

    public void Show(bool visible, bool force = false)
    {
        if (Shown == visible && !force) return;
        Shown = visible;
    }
}
