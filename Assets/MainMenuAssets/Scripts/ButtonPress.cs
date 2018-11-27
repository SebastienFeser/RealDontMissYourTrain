using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
This script is used to disable the mouse click glitch, that unselects a button when you click out of their bounds.
It selects the last button if the current selected game object is null.
*/

public class ButtonPress : MonoBehaviour {

    GameObject lastButtonSelected;

    void Start()
    {
        lastButtonSelected = new GameObject();
    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastButtonSelected);
        }
        else
        {
            lastButtonSelected = EventSystem.current.currentSelectedGameObject;
        }
    }
}
