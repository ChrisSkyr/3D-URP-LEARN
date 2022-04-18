using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    public override string GetDescription()
    {
        return "Pick Up";
    }

    public override void Interact()
    {
        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking Up" + item.name);
        bool wasPickedUp =  Inventory.Instance.Add(item);
        if(wasPickedUp) Destroy(gameObject);
    }
}
