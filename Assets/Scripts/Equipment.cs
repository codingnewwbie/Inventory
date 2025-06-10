using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public EquipTool currentEquip;

    public Character player;

    public StatusUI statusUI;

    private void Awake()
    {
        player = GetComponent<Character>();
    }

    public void EquipNew(ItemData data)
    {
        //기존 장비 해제
        if (currentEquip != null)
        {
            UnEquip(data); 
        }

        foreach (var equipable in data.Equipables)
        {
            switch (equipable.equipableType)
            {
                case EquipType.Attack:
                    player.IncreaseAttack((int)equipable.value);
                    break;
                case EquipType.Defense:
                    player.IncreaseDefense((int)equipable.value);
                    break;
                case EquipType.Health:
                    player.IncreaseHp((int)equipable.value);
                    break;
                case EquipType.Critical:
                    player.IncreaseCritical((int)equipable.value);
                    break;
            }
        }

        statusUI.UpdateStatusUI();
    }

    public void UnEquip(ItemData data)
    {
        foreach (var equipable in data.Equipables)
        {
            switch (equipable.equipableType)
            {
                case EquipType.Attack:
                    player.DecreaseAttack((int)equipable.value);
                    break;
                case EquipType.Defense:
                    player.DecreaseDefense((int)equipable.value);
                    break;
                case EquipType.Health:
                    player.DecreaseHp((int)equipable.value);
                    break;
                case EquipType.Critical:
                    player.DecreaseCritical((int)equipable.value);
                    break;
            }
        }
        
        statusUI.UpdateStatusUI();
    }
}
