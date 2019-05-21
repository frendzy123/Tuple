using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neg_score_increment : MonoBehaviour
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
    		score.isNegTriggered = true;
    	}
    }
    
    void OnTriggerExit2D(Collider2D other) {
    	if (other.tag == "Player") {
    		score.isNegTriggered = false;
    	}
    }
}
