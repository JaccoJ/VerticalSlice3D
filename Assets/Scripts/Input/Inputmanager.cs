﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputmanager : MonoBehaviour {

    //Connected to the manager Gameobject


    /*
     * This float allows for tighter or looser movement. It's confusing. 
     * You can further edit this in Project Settings -> Input
     */
    [SerializeField]
    private float axisThreshhold = 0.2f;

    /* 
     * functions that return values for the wasd/arrow buttons
     */
    public bool Up()
    {
        return Input.GetAxis(Strings.Movement.VERTICAL) > axisThreshhold;
    }
    public bool Down()
    {
        return Input.GetAxis(Strings.Movement.VERTICAL) < -axisThreshhold;
    }
    public bool Left()
    {
        return Input.GetAxis(Strings.Movement.HORIZONTAL) < -axisThreshhold;
    }
    public bool Right()
    {
        return Input.GetAxis(Strings.Movement.HORIZONTAL) > axisThreshhold;
    }
    public bool ClickOne()
    {
        return Input.GetMouseButton(0);
    }

    /* 
     * functions that return values for the mouse position
     */
    public float GetXRot()
    {
        return Input.GetAxis(Strings.Movement.MOUSE_X);
    }
    public float GetYRot()
    {
        return -Input.GetAxis(Strings.Movement.MOUSE_Y);
    }
}
