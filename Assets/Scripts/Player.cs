using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float range = 4f;
    [SerializeField] private Camera fpsCam;

    [SerializeField] private GameObject selected;
    [SerializeField] private OutlineScript selectable;
    [SerializeField] private Transform selection;

    [SerializeField] private bool isChanged = true;


    void Awake()
    {
        fpsCam = Camera.main;
    }

    void Update()
    {
            Hit();
    }

    void Hit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            selection = hit.transform;
            selectable = selection.GetComponent<OutlineScript>();
            


            if (selection != null)
            {
                if (selectable != null)
                {
                    
                    if (isChanged == true)
                    {
                        isChanged = false;
                        selectable.SetMaterial();
                    }
                }
            }




            
        }
        else
        {
            if(selectable != null)
            {
                selectable.ResetMaterial();
            }    
            isChanged = true;
            selection = null;
            
        }
        
    }
}
