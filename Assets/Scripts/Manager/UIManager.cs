using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum UIState

{
    Main,
    Status,
    Inventory,
}
public class UIManager : Singleton<UIManager>
{
    [Header("[UI State]")]
    [SerializeField] private UIState prevState;
    [SerializeField] public UIState currentState = UIState.Main;
    
    private MainUI _mainUI;
    private StatusUI _statusUI;
    private InventoryUI _inventoryUI;
    
    public MainUI MainUI => _mainUI;
    public StatusUI StatusUI => _statusUI;
    public InventoryUI InventoryUI => _inventoryUI;
    
    protected override void Awake()
    {
        base.Awake();

        // 자식 오브젝트에서 각각의 UI를 찾아 초기화
        _mainUI = GetComponentInChildren<MainUI>(true);
        _mainUI?.Init(this);
        _statusUI = GetComponentInChildren<StatusUI>(true);
        _statusUI?.Init(this);
        _inventoryUI = GetComponentInChildren<InventoryUI>(true);
        _inventoryUI?.Init(this);

        // 초기 상태를 설정.
        ChangeState(UIState.Main);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        
        _mainUI?.SetActive(currentState);
        _statusUI?.SetActive(currentState);
        _inventoryUI?.SetActive(currentState);
    }

    public void OpenMainMenu()
    {
        ChangeState(UIState.Main);
    }
    
    public void OpenStatus()
    {
        ChangeState(UIState.Status);
    }
    
    public void OpenInventory()
    {
        ChangeState(UIState.Inventory);
    }
    
    
}