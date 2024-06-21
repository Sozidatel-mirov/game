using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelInnf1 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyObj());
    }
    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }
}
