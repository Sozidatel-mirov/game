using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private GameObject player;
    private GameObject inventory;
    private GameObject listImventory1, listImventory2, listImventory3;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");

        listImventory1 = GameObject.Find("List-1");
        listImventory2 = GameObject.Find("List-2");
        listImventory3 = GameObject.Find("List-3");

        player = GameObject.FindGameObjectWithTag("Player").gameObject;

        ExitInventory();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventory.active)
            {
                ExitInventory();
            }
            else
            {
                Cursor.visible = true;
                inventory.SetActive(true);
                listImventory1.SetActive(true);
                listImventory2.SetActive(true);
                listImventory3.SetActive(true); 
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponentInChildren<PlayerLoop>().enabled = false;
            }

        }
    }
    public void ExitInventory()
    {
        Cursor.visible = false;
        inventory.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponentInChildren<PlayerLoop>().enabled = true;
    }
}
