using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorDetection : MonoBehaviour
{

    public GameObject _head;
    public Level4Score _playerScore;

    private Vector3 _mirrorHeadPosition = Vector3.zero;
    private float _accumulatedPoints = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(-_head.transform.position.x, _head.transform.position.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _mirrorHeadPosition = collision.gameObject.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float distance = Vector3.Distance(_mirrorHeadPosition, collision.gameObject.transform.position);
        if (distance < 0.8) {
            distance = 0;
        }
        Debug.Log(distance);
        _playerScore._playerScore +=  0.1f * distance;
        _mirrorHeadPosition = collision.gameObject.transform.position;
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        _accumulatedPoints = 0;
    }
}
