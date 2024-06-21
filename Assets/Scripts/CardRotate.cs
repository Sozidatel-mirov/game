using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRotate : MonoBehaviour
{
    GameObject[] cards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cards = GameObject.FindGameObjectsWithTag("Card");
        foreach(GameObject cart in cards)
        {
        cart.transform.Rotate(0, 0.2f, 0);
        }
    }
}
