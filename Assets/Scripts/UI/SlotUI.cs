using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public ItemData item;
    public InventoryUI inventory;
    public int index;
    public bool equipped = false;
    
    public Button button;
    public Image icon;
    public TextMeshProUGUI quantityText;

    // 해당 slot에 icon이랑 개수 보이게 하고
    public void SetItem()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
        quantityText.text = equipped ? "E" : string.Empty;
        
    }

    // 해당 slot 비우기
    public void RefreshUI()
    {
        item = null;
        icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;
    }

    public void OnClickButton()
    {
        inventory.SelectItem(index);
    }
}
