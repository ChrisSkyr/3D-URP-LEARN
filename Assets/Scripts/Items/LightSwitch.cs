using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    [SerializeField] private Light m_Light;
    public bool isOn;

    [SerializeField] private GameObject enabledSwitch;
    [SerializeField] private GameObject disabledSwitch;

    private void Start()
    {
        UpdateLight();    
    }

    private void Update()
    {
        if(isOn)
        {
            Destroy(gameObject.transform.GetChild(0));
            Instantiate(enabledSwitch);
        }
        else
        {
            if (transform.childCount > 1)
            {
                Destroy(gameObject.transform.GetChild(0));
                Instantiate(disabledSwitch);
            }
        }
    }

    void UpdateLight()
    {
        m_Light.enabled = isOn;
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
