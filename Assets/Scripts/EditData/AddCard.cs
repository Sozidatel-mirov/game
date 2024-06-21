using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AddCard : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField Name;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCard()
    {
        Item item = ScriptableObject.CreateInstance<Item>();
        item.name = Name.text;
        item.description = "123";
        item.power = "12";
        item.id = 14;
    }
}
