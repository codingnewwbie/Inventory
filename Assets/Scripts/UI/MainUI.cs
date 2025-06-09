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

    private Button _statusButton;
    private Button _inventoryButton;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override UIState GetUIState()
    {
        return UIState.Main;
    }
}
