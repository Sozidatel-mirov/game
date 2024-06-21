using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class InventorySlot
{
    public Item item;
    public int amount;
    public InventorySlot(Item item, int amount)
    { 
        this.item = item;
        this.amount = amount;
    }
}
public class InventoryScript : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> items = new List<InventorySlot>();
    [SerializeField] private int size = 27;
    [SerializeField] public UnityEvent OnInventoryChanged;

    public bool AddItems(Item item, int amount = 1)
    {
        foreach (InventorySlot slot in items)
        {
            if (slot.item.id == item.id)
            {
                slot.amount += amount;
                OnInventoryChanged.Invoke();
                return true;
            }
        }
        if (items.Count >= size) return false;
        InventorySlot new_slot = new InventorySlot(item, amount);
        items.Add(new_slot);
        OnInventoryChanged.Invoke();
        return true;
    }
    public Item GetItem(int i)
    {
        return i < items.Count ? items[i].item : null;
    }
    public int GetAmount(int i)
    {
        return i < items.Count ? items[i].amount : 0;
    }
    public int GetSize()
    {
        return items.Count;
    }
    public void RemoveItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items.RemoveAt(index);
            OnInventoryChanged.Invoke();
        }
        else
        {
            Debug.LogError("������� �������� �������� �� ������������� �������!");
        }
    }
}
