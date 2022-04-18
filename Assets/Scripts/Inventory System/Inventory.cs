using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public delegate void OnItemChanged();
    public OnItemChanged onItemXhangedCallBack;

    public int space = 15;

    public List<Item> items = new List<Item>();

    public void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        Instance = this;
    }

    public bool Add(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough space.");
                return false;
            }

            items.Add(item);

            if(onItemXhangedCallBack != null)
            onItemXhangedCallBack.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemXhangedCallBack != null)
            onItemXhangedCallBack.Invoke();
    }
}
