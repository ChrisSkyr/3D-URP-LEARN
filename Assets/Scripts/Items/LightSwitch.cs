using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class LightSwitch : Interactable
{
    private Animator animator;
    [SerializeField] private Light m_Light;

    public bool isOn;
    public string currentState;

    //Animations
    const string ENABLE_SWITCH = "Switch enable animation";
    const string DISABLE_SWITCH = "Switch disable animation";

    private void Start()
    {
        animator = GetComponent<Animator>();

        UpdateLight();    
    }

    private void ChangeAnimationState(string newState)
    {
        //stop the same animation to overwrite itself
        if (currentState == newState) return;

        //play the animation
        animator.Play(newState);

        //reassign the current state
        currentState = newState;
    }

    private void Update()
    {
      
    }

    void UpdateLight()
    {
        m_Light.enabled = isOn;
      
        if(isOn)
        {
            ChangeAnimationState(DISABLE_SWITCH);
        }
        else
       {
          ChangeAnimationState(ENABLE_SWITCH);
        }
    }

    public override string GetDescription()
    {
        if (isOn) return "Press [E] to turn <color=red>off</color> the light.";
        return "Press [E] to turn <color=green>on</color> the light.";
    }

    public override void Interact()
    {
        isOn = !isOn;
        UpdateLight();
    }
}
