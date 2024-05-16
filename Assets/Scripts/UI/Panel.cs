using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Panel : MonoBehaviour
{
    //The panel is useful for turning canvas widgets on and off.
    public bool Shown { get; private set; }

    protected virtual void Awake()
    {
        Show(false, force: true);
    }

    public void Open()
    {
        Show(true);
    }

    public void Close()
    {
        Show(false);
    }

    private void Show(bool visible, bool force = false)
    {
        if (Shown == visible && !force) return;
        Shown = visible;

        gameObject.SetActive(Shown);

        if (Shown)
            Refresh();
    }

    public abstract void Refresh();
}

