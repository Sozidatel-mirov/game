using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LookAtPlayer : MonoBehaviour
{
	private GameObject player;
	void Start()
    {
		player = GameObject.Find("Player");
	}
	void Update()
    {
		transform.LookAt(player.transform, Vector3.up);
	}
}
