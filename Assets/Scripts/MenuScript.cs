using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    private GameObject menu;

    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        menu = GameObject.FindGameObjectWithTag("Menu");
        ContinueGame();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!menu.active)
            {

                menu.SetActive(true);
                Cursor.visible = true;
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponentInChildren<PlayerLoop>().enabled = false;
            }
            else
            {
               
                ContinueGame();
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void ContinueGame()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponentInChildren<PlayerLoop>().enabled = true;
        Cursor.visible = false;
        menu.SetActive(false);
    }
}
