using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPlayer : MonoBehaviour
{
    private GameObject player, goMessenge;

    void Start()
    {
        goMessenge = GameObject.Find("goMessenge");
        player = GameObject.Find("Player");

        goMessenge.SetActive(false);
        player.transform.position = new Vector3(96, 6, -137);
    }
}
