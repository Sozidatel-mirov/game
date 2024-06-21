using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSpawn : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");

        GameObject.DontDestroyOnLoad(player);


        SceneManager.LoadScene(1);
    }

}
