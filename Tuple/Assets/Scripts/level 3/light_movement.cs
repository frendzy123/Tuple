using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_movement : MonoBehaviour
{
	private Quaternion targetAngle0 = Quaternion.Euler(52.641f,71.232f,66.853f);
	private Quaternion targetAngle1 = Quaternion.Euler(51.783f,-71.82301f,-67.32f);
	private int flip = 0;
	public float speed = 0.01f;
	public int flickerIntervalSec = 7;
	private float prevTime;
	public float elapsedTime = 0f; //change private
	private Light lightComp;

	public float flickerwait = 0.8f;
	public float flickerpause = 5f;
    // Start is called before the first frame update
    void Start()
    {
    	prevTime = Time.time;
    	lightComp = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
    	elapsedTime = elapsedTime + (Time.time - prevTime);
    	elapsedTime = Mathf.Round(Mathf.Repeat(elapsedTime, flickerIntervalSec));
    	prevTime = Time.time;

    	if (elapsedTime % flickerIntervalSec == 0) {
    		StartCoroutine(flicker());
    	}
    	else {
    		if (flip == 0) {
	    		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetAngle1, speed);
	    		if (this.transform.rotation == targetAngle1) {
	    			flip = 1;
	    		}
    		}
	    	else {
	    		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetAngle0, speed);
	    		if (this.transform.rotation == targetAngle0) {
	    			flip = 0;
	    		}
	    	}
    	}	
    }

    IEnumerator flicker() {
    	lightComp.intensity = 5f;

    	lightComp.enabled = !lightComp.enabled;
    	yield return new WaitForSecondsRealtime(flickerwait);
    	lightComp.enabled = lightComp.enabled;
    	yield return new WaitForSecondsRealtime(flickerwait);
/*
    	lightComp.enabled = !lightComp.enabled;
    	yield return new WaitForSecondsRealtime(flickerwait);
    	lightComp.enabled = lightComp.enabled;
    	yield return new WaitForSecondsRealtime(flickerwait);

    	lightComp.enabled = !lightComp.enabled;
    	yield return new WaitForSecondsRealtime(flickerwait);
    	lightComp.enabled = lightComp.enabled;
    	yield return new WaitForSecondsRealtime(flickerwait);

    	lightComp.enabled = !lightComp.enabled;
    	yield return new WaitForSecondsRealtime(flickerwait);
    	lightComp.enabled = lightComp.enabled;
    	yield return new WaitForSecondsRealtime(flickerwait);

    	//big break
    	lightComp.enabled = !lightComp.enabled;
    	yield return new WaitForSecondsRealtime(flickerpause);

    	lightComp.enabled = lightComp.enabled;
*/
    	lightComp.intensity = 16f;
    }
}
