using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (light_movement.isFlickerActive == true) {
			this.GetComponent<PolygonCollider2D> ().enabled = false;
		} else {
			this.GetComponent<PolygonCollider2D> ().enabled = true;
		}
    }

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			// change public static bool for bins to release jelly beans
		}
	}
}

