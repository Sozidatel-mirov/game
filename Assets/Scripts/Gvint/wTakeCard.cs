using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class wTakeCard : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text ball;
    [SerializeField] private List<Image> slots = new List<Image>();
    [SerializeField] private List<Item> items = new List<Item>();
    private Item selected;
    private int currentIndex = 0;
    private int nowBalls = 0;

    public void ChooseSlot()
    {
        try
        {
            selected = items[0];
        }
        catch (Exception ex) { }
        
        if (selected != null)
        {
            SetNextSprite(selected.icon, ref selected);
            nowBalls = Convert.ToInt32(ball.text);
            nowBalls += Convert.ToInt32(selected.power);
            ball.text = nowBalls.ToString();
            
            items.Remove(selected);
            selected = null;
        }
        else Debug.Log("kus");

    }
    public void SetNextSprite(Sprite selectedSprite, ref Item item)
    {
        // ѕровер€ем, что у нас есть еще изображени€ в списке
        if (currentIndex < slots.Count)
        {
            // ”станавливаем спрайт дл€ текущего изображени€
            slots[currentIndex].sprite = selectedSprite;

            // ”величиваем индекс, чтобы перейти к следующему изображению
            currentIndex++;
        }
        else
        {
            Debug.Log("¬се изображени€ заполнены.");
        }
    }
}
