using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject inventory;
    [SerializeField]private GameObject listImventory1, listImventory2, listImventory3;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Page1()
    {
        listImventory1.SetActive(true);
        listImventory2.SetActive(false);
        listImventory3.SetActive(false);
    }
    public void Page2()
    {
        listImventory1.SetActive(false);
        listImventory2.SetActive(true);
        listImventory3.SetActive(false);
    }
    public void Page3()
    {
        listImventory1.SetActive(false);
        listImventory2.SetActive(false);
        listImventory3.SetActive(true);
    }


}
