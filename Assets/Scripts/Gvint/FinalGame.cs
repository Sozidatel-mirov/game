using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGame : MonoBehaviour
{
    [SerializeField] private GameObject winInfo, loseInfo, info;
    int gameballs, wballs;
    [SerializeField] private TMPro.TMP_Text gball, wball;
    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.SetActive(false);
        loseInfo.SetActive(false);
        winInfo.SetActive(false);
        info.SetActive(false);
    }

    // Update is called once per frame
    public void Final()
    {
        gameballs = Convert.ToInt32(gball.text);
        wballs = Convert.ToInt32(wball.text);
        gameObject.SetActive(true);
        if(gameballs < wballs)
        {
            loseInfo.SetActive(true);
        }
        else if(gameballs > wballs)
        {
            winInfo.SetActive(true);
        }
        else if(gameballs == 0)
        {
            loseInfo.SetActive(true);
        }
        else 
        {
            info.SetActive(true);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
