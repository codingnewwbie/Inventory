using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : BaseUI
{
    [SerializeField] private Button _backButton;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI amountText;
    
    public SlotUI[] slots;
    public GameObject inventoryWindow;
    public Transform slotPanel;
    
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStat;
    public TextMeshProUGUI selectedItemStatValue;
    public GameObject equipButton;
    public GameObject unequipButton;
    public Character player;
    
    private ItemData selectedItem;
    private int selectedItemIndex = 0;
    
    private int currentEquipIndex;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        
        _backButton.onClick.AddListener(OnClickBackButton);
    }
    
    protected override UIState GetUIState()
    {
        return UIState.Inventory;
    }
    
    void OnClickBackButton()
    {
        uiManager.OpenMainMenu();
    }
    
    void Start()
    {
        player.AddItem += AddItem;
        
        slots = new SlotUI[slotPanel.childCount];
    
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<SlotUI>();
            slots[i].index = i;
            slots[i].inventory = this;
        }
        
        string[] itemPaths = {
            "ScriptableObject/Sword",
            "ScriptableObject/Ring",
            "ScriptableObject/Armor"
        };
    
        foreach (string path in itemPaths)
        {
            ItemData testItem = Resources.Load<ItemData>(path);
            if (testItem != null)
            {
                GameManager.Instance.itemData = testItem;
                AddItem();
            }
        }
        
        ClearSelectedItemWindow();
    }
    
    
    void ClearSelectedItemWindow()
    {
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedItemStat.text = string.Empty;
        selectedItemStatValue.text = string.Empty;
        
        equipButton.SetActive(false);
        unequipButton.SetActive(false);
    }

    void AddItem()
    {
        ItemData data = GameManager.Instance.itemData;
        
        //비어 있는 슬롯 가져온다.
        SlotUI emptySlot = GetEmptySlot();
    
        // 빈 슬롯이 있다면 중첩 가능하든 아니든 일단 개수 1로 설정.
        if (emptySlot != null)
        {
            emptySlot.item = data;
            UIUpdate();
            GameManager.Instance.itemData = null;
            return;
        }
        
        //없다면
        GameManager.Instance.itemData = null;
    }
    
    void UIUpdate()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                slots[i].SetItem();                
            }
            else
            {
                slots[i].RefreshUI();
            }
        }
    }

    SlotUI GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                return slots[i];
            }            
        }
        return null;
    }
    
    // 
    public void SelectItem(int index)
    {
        if (slots[index].item == null) return;
    
        selectedItem = slots[index].item;
        selectedItemIndex = index;
        
        selectedItemName.text = selectedItem.displayName;
        selectedItemDescription.text = selectedItem.description;
    
        selectedItemStat.text = string.Empty;
        selectedItemStatValue.text = string.Empty;
        
        for (int i = 0; i < selectedItem.Equipables.Length; i++)
        {
            selectedItemStat.text += selectedItem.Equipables[i].equipableType + "\n";
            selectedItemStatValue.text += selectedItem.Equipables[i].value + "\n";
        }
        
        equipButton.SetActive(!slots[index].equipped);
        unequipButton.SetActive(slots[index].equipped);
    }
    
    public void OnEquipButton()
    {
        if (slots[currentEquipIndex].equipped)
        {
            // 해제
            UnEquip(currentEquipIndex);
        }
        
        slots[selectedItemIndex].equipped = true;
        currentEquipIndex = selectedItemIndex;
        
        GameManager.Instance.player.equip.EquipNew(selectedItem);
        UIUpdate();
        
        SelectItem(selectedItemIndex);
        
    }
    
    void UnEquip(int index)
    {
        slots[index].equipped = false;
        GameManager.Instance.player.equip.UnEquip(slots[index].item);
        UIUpdate();
    
        if (selectedItemIndex == index)
        {
            SelectItem(selectedItemIndex);
        }
    }
    
    public void OnUnEquipmentButton()
    {
        UnEquip(currentEquipIndex);
    }
}
