using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class PlayerControls : MonoBehaviour {
    public GameObject controller;
    public float xMagnitude;
    public float yMagnitude;
    public bool isInverted;

    private float shiftX;
    private float shiftY;

    private float initialX;
    private float initialY;

    private float inversion = 1.0f;
    private Rigidbody2D rg2d;

    private int startFrame = 0;
    private int endFrame = 10;

    private float prevX = 0f;
    private float prevY = 0f;

    void Start() {
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        initialX = rg2d.position.x;
        initialY = rg2d.position.y;
    }
/*
    //confirmed working, inversion behavior not ideal
    void FixedUpdate() {
        if (startFrame < endFrame) {
            startFrame += 1;
        }
        else if (startFrame == endFrame) {
            shiftX = controller.transform.position.x - initialX;
            shiftY = controller.transform.position.y - initialY;
            startFrame += 1;
        }

        if (isInverted == true) {
            inversion = -1.0f;
        }
        else {
            inversion = 1.0f;
        }

        float scaledX = (controller.transform.position.x - shiftX - initialX) * xMagnitude; 
        float scaledY = (controller.transform.position.y - shiftY - initialY) * yMagnitude;

        Vector2 newPos = new Vector2(scaledX + initialX, scaledY + initialY);
        rg2d.MovePosition(newPos);
    }
*/
    //in progress, no centering and no inversion behavior
    void FixedUpdate() {
        if (isInverted == true) {
            inversion = -1.0f;
        }
        else {
            inversion = 1.0f;
        }



        float scaledX = inversion * (controller.transform.position.x - prevX) * xMagnitude; 
        float scaledY = (controller.transform.position.y - prevY) * yMagnitude;

        Vector2 newPos = new Vector2(scaledX - initialX, scaledY - initialY);
        rg2d.MovePosition(newPos);
    }
}

