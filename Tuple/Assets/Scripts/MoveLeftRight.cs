using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{

	public float limit;
	public Rigidbody2D rb2d;
	public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x >= limit || gameObject.transform.position.x <= -limit) {
        	velocity = -velocity;
        }

        rb2d.velocity = new Vector2(velocity, 0);
    }
}
