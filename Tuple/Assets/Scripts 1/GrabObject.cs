using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{

    private HingeJoint2D _hj;
    // Start is called before the first frame update
    void Start()
    {
        _hj = this.GetComponentInParent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerControls>().IsGrabbing())
            {
                _hj.enabled = true;
                _hj.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            }
            else
            {
                _hj.connectedBody = null;
                _hj.enabled = false;
            }
        }
    }
}
