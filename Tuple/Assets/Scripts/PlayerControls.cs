using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class PlayerControls : MonoBehaviour {
    public GameObject controller;
    public float xMagnitude;
    public float yMagnitude;
    public bool grounded = false;
    public float range;
    public PlayerControls otherHead;

    Rigidbody2D rg2d;
    float currentGroundPos = 0f;
    float currentControllerPos;

    void Start() {
        rg2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (otherHead.grounded) {
            float yPos = Mathf.Clamp(currentGroundPos + (controller.transform.position.y - currentControllerPos) * yMagnitude, currentGroundPos - range, currentGroundPos + range);
            Vector2 newPos = new Vector2(controller.transform.position.x * xMagnitude, yPos);
            rg2d.MovePosition(newPos);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Ground") {
            grounded = true;
            currentGroundPos = col.gameObject.transform.position.y + col.gameObject.GetComponent<Collider2D>().bounds.size.y;
            currentControllerPos = controller.transform.position.y;
            Debug.Log(currentGroundPos);
        }
    }
}

