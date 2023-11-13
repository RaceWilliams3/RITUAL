using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMouseOver : MonoBehaviour
{
    public GameObject cursor1;
    public GameObject cursor2;

    private bool isMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        cursor1.SetActive(true);
        cursor2.SetActive(true);
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        cursor1.SetActive(false);
        cursor2.SetActive(false);
    }
    /*
    void Update()
    {
        cursor1.SetActive(isMouseOverUI());
        cursor2.SetActive(isMouseOverUI());
    }*/
}
