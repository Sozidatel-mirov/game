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
            panelScript.ResetSelectedItem(); // Сброс выбранного предмета после использования
            ChooseSlotW();
            // Если индекс удаленного предмета получен успешно
            if (selectedIndex != -1)
            {
                // Очищаем спрайт в слоте с полученным индексом
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
        // Проверяем, что у нас есть еще изображения в списке
        if (currentIndex < slots.Count)
        {
            // Устанавливаем спрайт для текущего изображения
            slots[currentIndex].sprite = selectedSprite;

            // Увеличиваем индекс, чтобы перейти к следующему изображению
            currentIndex++;
        }
        else
        {
            Debug.Log("Все изображения заполнены.");
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
        // Проверяем, что у нас есть еще изображения в списке
        if (currentIndexW < slots.Count)
        {
            // Устанавливаем спрайт для текущего изображения
            slotsW[currentIndexW].sprite = selectedSprite;

            // Увеличиваем индекс, чтобы перейти к следующему изображению
            currentIndexW++;
        }
        else
        {
            Debug.Log("Все изображения заполнены.");
        }
    }
    private int RemoveItemFromInventory(Item item)
    {
        for (int i = 0; i < inventoryScript.GetSize(); i++)
        {
            if (inventoryScript.GetItem(i) == item)
            {
                inventoryScript.RemoveItem(i);
                return i; // Возвращаем индекс удаленного предмета
            }
        }
        return -1; // Если предмет не был найден, возвращаем -1
    }

}
