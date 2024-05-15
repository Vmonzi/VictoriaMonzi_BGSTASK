using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SO/ItemData", order = 1)]
public class Item_SO : ScriptableObject
{
    public int cost;
    public int sellCost;
    public Sprite icon;

}
