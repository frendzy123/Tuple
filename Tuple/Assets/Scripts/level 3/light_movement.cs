using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_movement : MonoBehaviour
{
	private Quaternion targetAngle0 = Quaternion.Euler(52.641f,71.232f,66.853f);
	private Quaternion targetAngle1 = Quaternion.Euler(51.783f,-71.82301f,-67.32f);
	private int flip = 0;
	private float prevTime;
	private int elapsedTime = 1;
	private Light lightComp;

	public float lightRotationSpeed = 0.01f;
	public int flickerIntervalSec = 7;
	public float flickerStutterInterval = 0.1f;
	public float flickerPauseInterval = 7f;
	public bool isFlickerActive = false;

    // Start is called before the first frame update
    void Start()
    {
    	prevTime = Time.time;
    	lightComp = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
    	if (isFlickerActive == false) {
	    	if (elapsedTime % flickerIntervalSec == 0) {
	    		elapsedTime = 1;
	    		StartCoroutine(flicker());
	    	}
	    	if (Mathf.Round(Time.time - prevTime) == 1) {
	    		elapsedTime = (elapsedTime + 1) % flickerIntervalSec;
	    		prevTime = Time.time;
	    	}
			if (flip == 0) {
	    		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetAngle1, lightRotationSpeed);
	    		if (this.transform.rotation == targetAngle1) {
	    			flip = 1;
	    		}
			}
	    	else if (flip == 1) {
	    		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetAngle0, lightRotationSpeed);
	    		if (this.transform.rotation == targetAngle0) {
	    			flip = 0;
	    		}
	    	}
    	}
    }

    IEnumerator flicker() {
    	isFlickerActive = true;
    	lightComp.intensity = 5f;

    	lightComp.enabled = false;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);
    	lightComp.enabled = true;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);

    	lightComp.enabled = false;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);
    	lightComp.enabled = true;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);

    	lightComp.enabled = false;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);
    	lightComp.enabled = true;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);

    	lightComp.enabled = false;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);
    	lightComp.enabled = true;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);

    	//big break
    	lightComp.enabled = false;
    	yield return new WaitForSecondsRealtime(flickerPauseInterval);

    	lightComp.enabled = true;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);

    	lightComp.enabled = false;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);
    	lightComp.enabled = true;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);

    	lightComp.enabled = false;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);
    	lightComp.enabled = true;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);

    	lightComp.enabled = false;
    	yield return new WaitForSecondsRealtime(flickerStutterInterval);

    	lightComp.intensity = 16f;
    	lightComp.enabled = true;
    	isFlickerActive = false;
    	prevTime = Time.time;
    }
}
