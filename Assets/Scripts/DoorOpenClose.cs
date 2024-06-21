using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DoorOpenClose : MonoBehaviour
{
    private GameObject player, door, open, close, phone;
    Animator animator;
    private bool inTrigger;
    void Start()
    {
        animator = transform.GetComponent<Animator>();
		player = GameObject.Find("Player");
        door = GameObject.Find("door");
        open = door.transform.GetChild(1).gameObject;
        close = door.transform.GetChild(2).gameObject;
        phone = door.transform.GetChild(0).gameObject;

		close.SetActive(false);
        open.SetActive(false);
		phone.SetActive(false);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
		phone.SetActive(true);
        if (!animator.GetBool("isOpen"))
        {
            close.SetActive(true);
        }
        else
        {
            open.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        phone.SetActive(false);
        close.SetActive(false);
        open.SetActive(false);
    }
    void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (!animator.GetBool("isOpen"))
            {

                animator.SetBool("isOpen", true);
                close.SetActive(false);
                open.SetActive(true);
            }
            else
            {
                animator.SetBool("isOpen", false);
                close.SetActive(true);
                open.SetActive(false);
            }
        }
    }
}
