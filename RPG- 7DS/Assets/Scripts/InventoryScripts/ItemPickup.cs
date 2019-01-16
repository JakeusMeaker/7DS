using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable {

    public Item item;
    public GameObject itemObject;
    public GameObject examinationPoint;
    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
       

        if (wasPickedUp)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

    }

    public void Examine()
    {
        gameObject.SetActive(true);
    }

    

}
