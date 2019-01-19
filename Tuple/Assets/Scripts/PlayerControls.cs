using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerControls : MonoBehaviour {

    public SteamVR_Action_Vector2 touchpadPos;
    public SteamVR_Action_Boolean touchpadClick;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (touchpadClick) {
            if (touchpadPos.x > 0.5)
            {
                Debug.Log("Right");
            }
            else if(touchpadPos.x <= 0.5){
                Debug.Log("Left");
            }
        }
	}
}
