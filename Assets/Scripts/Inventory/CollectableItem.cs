using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class CollectableItem : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private int amount = 1;
    [SerializeField] private GameObject messenge;

    private void OnTriggerEnter(Collider other)
    {
        if (!item) return;
        InfMess();
        var inventory = other.GetComponent<InventoryScript>();

        if (inventory)
        {
            if(inventory.AddItems(item, amount))
            Destroy(gameObject);
        }
    }
    
    public void InfMess()
    {
        Instantiate(messenge);
    }
}
