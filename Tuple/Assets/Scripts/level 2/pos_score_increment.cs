using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pos_score_increment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
    	if (other.tag == "Player") {
    		score.isPosTriggered = true;
    	}
    }

    void OnTriggerExit2D(Collider2D other) {
    	if (other.tag == "Player") {
    		score.isPosTriggered = false;
    	}
    }
}
