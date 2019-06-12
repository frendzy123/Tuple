using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjectGeneral : MonoBehaviour
{

    public bool _dropped = false;
    public float _droppedTime;

    public bool _grabbed = false;
    private Vector3 _newPosition;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_grabbed) {
            this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().MovePosition(_player.transform.position);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerControls player = collision.gameObject.GetComponent<PlayerControls>();
            if (player.IsGrabbing() && !player.grabbed) {
                _grabbed = true;
                player.grabbed = true;
            }
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerControls player = collision.gameObject.GetComponent<PlayerControls>();
            if (player.IsGrabbing() && !player.grabbed)
            {
                _player = collision.gameObject;
                player.grabbed = true;
                this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
                _grabbed = true;
            }
            else if(!player.IsGrabbing())
            {
                _grabbed = false;
                player.grabbed = false;
                StartCoroutine("Dropped");
            }
        }
    }

    IEnumerator Dropped()
    {
        _dropped = true;
        yield return new WaitForSeconds(_droppedTime);
        _dropped = false;
    }
}
