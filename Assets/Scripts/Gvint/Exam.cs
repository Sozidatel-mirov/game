using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exam : MonoBehaviour
{
    private GameObject player, goMessenge, goNext, goNextPhone;

    private bool inTrigger;
    void Start()
    {
        player = GameObject.Find("Player");
        goMessenge = GameObject.Find("examMessenge");
        goNext = goMessenge.transform.GetChild(1).gameObject;
        goNextPhone = goMessenge.transform.GetChild(0).gameObject;
        goNext.SetActive(false);
        goNextPhone.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        goNext.SetActive(true);
        goNextPhone.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        goNext.SetActive(false);
        goNextPhone.SetActive(false);
    }
    void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.F))
        {
            GameObject.DontDestroyOnLoad(player);



            SceneManager.LoadScene(5);
        }
    }
}
