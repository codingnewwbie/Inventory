using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : BaseUI
{
    private int _attack, _defense, _hp, _critical;
    [SerializeField] private Button _backButton;
    [SerializeField] private TextMeshProUGUI APText;
    [SerializeField] private TextMeshProUGUI DPText;
    [SerializeField] private TextMeshProUGUI HPText;
    [SerializeField] private TextMeshProUGUI CriText;
    
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        
        _backButton.onClick.AddListener(OnClickBackButton);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateStatusUI();
    }

    protected override UIState GetUIState()
    {
        return UIState.Status;
    }
    
    void OnClickBackButton()
    {
        uiManager.OpenMainMenu();
    }
    
    
    public void UpdateStatusUI()
    {
        APText.text = GameManager.Instance.player.Attack.ToString();
        DPText.text = GameManager.Instance.player.Defense.ToString();
        HPText.text = GameManager.Instance.player.Hp.ToString();
        CriText.text = GameManager.Instance.player.Critical.ToString();
    }

}
