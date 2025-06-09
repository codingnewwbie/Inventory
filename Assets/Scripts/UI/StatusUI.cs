using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : BaseUI
{
    private int _attack, _defense, _hp, _critical;
    private Button _backButton;
    
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
        return UIState.Status;
    }
}
