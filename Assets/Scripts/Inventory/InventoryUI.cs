using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<Image> icons = new List<Image>();
    [SerializeField] private Sprite nonImageSprite;
    private Item selectedItem;
    InventoryScript script;
    private void Start()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            int index = i; // Локальная копия переменной, чтобы избежать замыкания
            icons[i].GetComponent<Button>().onClick.AddListener(() => OnButtonClick(index));
        }
    }
    public void UpdateUI(InventoryScript inventory)
    {
        script = inventory;
        for(int i = 0; i < inventory.GetSize() && i < icons.Count; i++)
        {
            icons[i].sprite = inventory.GetItem(i).icon;
        }
    }
    public void UpdateUIR(int index)
    {
        foreach(Image image in icons)
        {
            image.sprite = nonImageSprite;
        }
       
       
    }
    public void ResetSelectedItem()
    {
        selectedItem = null;
    }
    private void OnButtonClick(int index)
    {
        selectedItem = script.GetItem(index);
        Debug.Log("Нажата кнопка слота: " + selectedItem.name);
    }
    internal Item GetItem()
    {
        return selectedItem;
    }
}
