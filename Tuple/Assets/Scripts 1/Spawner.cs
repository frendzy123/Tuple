using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	public GameObject fallingObject;
	public int frameLimit;
	public float limit;

	private int frameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(frameCount == 0) {
        	Instantiate(fallingObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        	float xPos = limit * Random.value;
        	gameObject.transform.position = new Vector3(xPos, gameObject.transform.position.y, 0);
        }

        frameCount++;

        if(frameCount == frameLimit) {
        	frameCount = 0;
        }
    }
}
