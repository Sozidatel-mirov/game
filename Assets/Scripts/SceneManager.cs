using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{

    private GameObject player, goMessenge, goNext, phone;

    private bool inTrigger;
    private int nowScene;
    void Start()
    {
        nowScene = SceneManager.GetActiveScene().buildIndex;
        player = GameObject.Find("Player");
        goMessenge = GameObject.Find("goMessenge");
		phone = goMessenge.transform.GetChild(0).gameObject;
        goNext = goMessenge.transform.GetChild(1).gameObject;
        goNext.SetActive(false);
		phone.SetActive(false);

	}

    private void OnTriggerEnter(Collider other)
    {
        
        inTrigger = true;
        goMessenge.SetActive(true);
        goNext.SetActive(true);
        phone.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        goMessenge.SetActive(false);
        goNext.SetActive(false);
        phone.SetActive(false);
    }

    private void Update()
    {
        if(inTrigger && Input.GetKeyDown(KeyCode.F))
        {
            if(SceneManager.GetActiveScene().buildIndex != 4)
            {
                GameObject.DontDestroyOnLoad(player);
                SceneManager.LoadScene(nowScene + 1);
            }
        }
    }
}
