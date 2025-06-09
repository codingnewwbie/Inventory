using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : BaseUI
{
    private int _attack, _defense, _hp, _critical;
    [SerializeField] private Button _backButton;
    
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        
        _backButton.onClick.AddListener(OnClickBackButton);
    }
    
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
    
    void OnClickBackButton()
    {
        uiManager.OpenMainMenu();
    }
}
