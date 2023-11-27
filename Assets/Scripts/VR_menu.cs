using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_menu : MonoBehaviour
{
    public GameObject UI;
    public GameObject UIAnchor;
    private bool UIActive;
    
    void Start()
    {
        UI.SetActive(false);
    }

    
    void Update()
    {
        /*if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            UI.SetActive(!UI.activeSelf);
        }*/
        
    }
}
