using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerControls : MonoBehaviour {

    public SteamVR_Action_Vector2 touchpadPos;
    public SteamVR_Action_Boolean touchpadClick;

    Vector2 touchpadPosVal;
    bool touchpadClickVal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        touchpadClickVal = touchpadClick.GetState(SteamVR_Input_Sources.RightHand);
        touchpadPosVal = touchpadPos.GetAxis(SteamVR_Input_Sources.RightHand);

        if (touchpadClickVal) {
            if (touchpadPosVal.x > 0.5)
            {
                gameObject.transform.Translate(Vector3.right * 0.05fs);
            }
            else if(touchpadPosVal.x <= 0.5){
                gameObject.transform.Translate(Vector3.left * 0.05f);
            }
        }
	}
}

