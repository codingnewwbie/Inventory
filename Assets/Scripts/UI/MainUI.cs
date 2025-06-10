using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : BaseUI
{
    private string _id;
    private int _level;
    private int _gold;
    private int _exp;

    [SerializeField] private Button _statusButton;
    [SerializeField] private Button _inventoryButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        
        _statusButton.onClick.AddListener(OnClickStatButton);
        _inventoryButton.onClick.AddListener(OnClickInvenButton);
    }

    protected override UIState GetUIState()
    {
        return UIState.Main;
    }
    
    void OnClickStatButton()
    {
        uiManager.OpenStatus();
    }

    void OnClickInvenButton()
    {
        uiManager.OpenInventory();
    }
}
