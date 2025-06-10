using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equip,
}

public enum EquipType
{
    Health,
    Attack,
    Defense,
    Critical,
}

[System.Serializable]
public class ItemDataEquipable
{
    public EquipType equipableType;
    public float value;
}


[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public EquipType types;
    public Sprite icon;
    
    [Header("Equipable")]
    public ItemDataEquipable[] Equipables;
}