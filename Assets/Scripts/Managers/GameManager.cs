using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private UIManager _uiManager;

    public UIManager UIManager => _uiManager;

    public bool CanShop { get; set; }


    private void Awake()
    {
        if (!Instance) Instance = this;
        else Destroy(Instance);
    }
}

