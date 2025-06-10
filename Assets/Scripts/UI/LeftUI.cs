using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeftUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI maxExpText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI rankText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        expText.text = GameManager.Instance.player.Exp.ToString();
        maxExpText.text =  "/     " + GameManager.Instance.player.MaxExp.ToString();
        goldText.text = GameManager.Instance.player.Gold.ToString();
        levelText.text = GameManager.Instance.player.Level.ToString();
        nameText.text = GameManager.Instance.player.Name;
        rankText.text = GameManager.Instance.player.Rank;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override UIState GetUIState()
    {
        return UIState.None;
    }
}
