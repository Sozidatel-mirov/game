using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDialog : MonoBehaviour
{
    [SerializeField] private Teacher teacher;
    GameObject dialog, startDialog, phone;
    private bool inTrig = false;
    [SerializeField] private DialogManager dialogManager;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        dialog = GameObject.Find("dialogs");
        startDialog = GameObject.Find("startDialog");
		phone = GameObject.Find("phonegovr");


		dialog.SetActive(false);
        startDialog.SetActive(false);
		phone.SetActive(false);

	}
    

    void Update()
    {
        
        if (inTrig && Input.GetKeyDown(KeyCode.F))
        {
            dialog.SetActive(true);
            startDialog.SetActive(false);
            phone.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponentInChildren<PlayerLoop>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        dialogManager.SetTeacher(teacher, gameObject);

        startDialog.SetActive(true);
		phone.SetActive(true);
		inTrig = true;
        Cursor.visible = true;

    }
    private void OnTriggerExit(Collider other)
    {
        dialog.SetActive(false);
        startDialog.SetActive(false);
		phone.SetActive(false);
		inTrig = false;
        Cursor.visible = false;
    }
}
