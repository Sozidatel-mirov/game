using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class TakeCard : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text ball;
    [SerializeField] private List<Image> slots = new List<Image>();
    private GameObject scriptPanel;
    private InventoryUI panelScript;
    private Item selected;
    private int currentIndex = 0;
    private int nowBalls = 0;
    private InventoryScript inventoryScript;

    [SerializeField] private TMPro.TMP_Text ballW;
    [SerializeField] private List<Image> slotsW = new List<Image>();
    [SerializeField] private List<Item> items = new List<Item>();
    private Item selectedW;
    private int currentIndexW = 0;
    private int nowBallsW = 0;

    public void ChooseSlot()
    {
        scriptPanel = GameObject.Find("Panel");
        panelScript = scriptPanel.GetComponent<InventoryUI>();
        inventoryScript = FindObjectOfType<InventoryScript>();
        selected = panelScript.GetItem();
        if (selected != null)
        {
            SetNextSprite(selected.icon, ref selected);
            nowBalls = Convert.ToInt32(ball.text);
            nowBalls += Convert.ToInt32(selected.power);
            ball.text = nowBalls.ToString();
            int selectedIndex = RemoveItemFromInventory(selected);
            selected = null;
            panelScript.ResetSelectedItem(); // ����� ���������� �������� ����� �������������
            ChooseSlotW();
            // ���� ������ ���������� �������� ������� �������
            if (selectedIndex != -1)
            {
                // ������� ������ � ����� � ���������� ��������
                panelScript.UpdateUIR(selectedIndex);
                panelScript.UpdateUI(inventoryScript);
            }
        }
        else
        {
            Debug.Log("kus");
        }
    }

    public void SetNextSprite(Sprite selectedSprite, ref Item item)
    {
        // ���������, ��� � ��� ���� ��� ����������� � ������
        if (currentIndex < slots.Count)
        {
            // ������������� ������ ��� �������� �����������
            slots[currentIndex].sprite = selectedSprite;

            // ����������� ������, ����� ������� � ���������� �����������
            currentIndex++;
        }
        else
        {
            Debug.Log("��� ����������� ���������.");
        }
    }
    public void ChooseSlotW()
    {
        try
        {
            selectedW = items[0];
        }
        catch (Exception ex) { }

        if (selectedW != null)
        {
            SetNextSpriteW(selectedW.icon, ref selectedW);
            nowBallsW = Convert.ToInt32(ballW.text);
            nowBallsW += Convert.ToInt32(selectedW.power);
            ballW.text = nowBallsW.ToString();

            items.Remove(selectedW);
            selectedW = null;
        }
        else Debug.Log("kusW");

    }
    public void SetNextSpriteW(Sprite selectedSprite, ref Item item)
    {
        // ���������, ��� � ��� ���� ��� ����������� � ������
        if (currentIndexW < slots.Count)
        {
            // ������������� ������ ��� �������� �����������
            slotsW[currentIndexW].sprite = selectedSprite;

            // ����������� ������, ����� ������� � ���������� �����������
            currentIndexW++;
        }
        else
        {
            Debug.Log("��� ����������� ���������.");
        }
    }
    private int RemoveItemFromInventory(Item item)
    {
        for (int i = 0; i < inventoryScript.GetSize(); i++)
        {
            if (inventoryScript.GetItem(i) == item)
            {
                inventoryScript.RemoveItem(i);
                return i; // ���������� ������ ���������� ��������
            }
        }
        return -1; // ���� ������� �� ��� ������, ���������� -1
    }

}
