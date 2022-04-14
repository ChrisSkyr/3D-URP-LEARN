using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float range = 4f;
     private Camera fpsCam;

     private GameObject selected;
     private OutlineScript selectable;
     private Transform selection;

     private bool isChanged = true;

    [SerializeField] Interactable interactable;
    [SerializeField] TMPro.TextMeshProUGUI interactionText;
    [SerializeField] bool successfulHit = false;


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
            interactable = hit.collider.GetComponent<Interactable>();

            successfulHit = false;


            if (selection != null)
            {
                if (selectable != null )
                {
                    
                    if (isChanged == true)
                    {
                        isChanged = false;
                        selectable.SetMaterial();
                    }
                }

                if (interactable != null)
                {
                    HandleInteraction(interactable);
                    interactionText.text = interactable.GetDescription();
                    successfulHit = true;
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
            successfulHit = false;
        }

        if (!successfulHit) interactionText.text = "";
        

        void HandleInteraction(Interactable interactable)
        {
            KeyCode key = KeyCode.E;
            switch (interactable.interactionType)
            {
                case Interactable.InteractionType.Click:
                    if(Input.GetKeyDown(key))
                    {
                        interactable.Interact();
                    }
                    break;
                case Interactable.InteractionType.Hold:
                    if(Input.GetKey(key))
                    {
                        interactable.Interact();
                    }
                    break;
                case Interactable.InteractionType.Pay:
                    //Payment System
                    break;

                default:
                    throw new System.Exception("Unsupported type of interactable.");
            }
        }
    }
}
