using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
