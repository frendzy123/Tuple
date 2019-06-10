using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SafeCover") {
            Debug.Log(collision.contacts[0].normal);
            Vector3 reflect = Vector3.Reflect(collision.rigidbody.velocity, collision.contacts[0].normal);

            if () {
            }

            Debug.Log(collision.rigidbody.velocity);
        }
    }
}
