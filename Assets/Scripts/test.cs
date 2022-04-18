using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{
    public GameObject tesOj;

    public Dictionary<string, GameObject> inventory = new Dictionary<string, GameObject>();




    public void Start()
    {
        for (int i = 0; i < tesOj.transform.childCount; i++)
        {
            inventory.Add(tesOj.transform.GetChild(i).gameObject.name, tesOj.transform.GetChild(i).gameObject);
        }
    }

    public void Update()
    {
        Instantiate(inventory["Cube"]);
        Instantiate(inventory["Sphere"]);
        Instantiate(inventory["Plane"]);
    }
}
