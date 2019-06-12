using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_trigger : MonoBehaviour
{
    public bin_behavior _rightBin;
    public bin_behavior _leftBin;

    private GameObject[] _playerList = {null, null};
    private Vector3[] _playerRecordedPosition = { Vector3.zero, Vector3.zero };

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

	private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.tag == "Player") {
            // change public static bool for bins to release jelly beans
            if (collision.name == "RightHead")
            {
                _playerList[0] = collision.gameObject;
                _playerRecordedPosition[0] = collision.gameObject.transform.position;
            }

            if (collision.name == "LeftHead")
            {
                _playerList[1] = collision.gameObject;
                _playerRecordedPosition[1] = collision.gameObject.transform.position;
            }
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // change public static bool for bins to release jelly beans
            if (collision.name == "RightHead")
            {
                if (_playerList[0] != null)
                {
                    if (Vector3.Distance(_playerRecordedPosition[0], collision.gameObject.transform.position) > 1)
                    {
                        _rightBin.Vommit();
                    }
                }
            }

            if (collision.name == "LeftHead")
            {
                if (_playerList[1] != null)
                {
                    if (Vector3.Distance(_playerRecordedPosition[1], collision.gameObject.transform.position) > 1)
                    {
                        _leftBin.Vommit();
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // change public static bool for bins to release jelly beans
            if (collision.name == "RightHead")
            {
                _playerList[0] = null;
            }

            if (collision.name == "LeftHead")
            {
                _playerList[1] = null;
            }
        }
    }
}

