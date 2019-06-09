using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispense : MonoBehaviour
{
    public GameObject _jellybean;
    public float _launchMagnitude;
    public int _upperAngle;
    public int _lowerAngle;

    private bool _left = false;
    private Transform _directionPoint;

    // Start is called before the first frame update
    void Start()
    {

        _directionPoint = this.gameObject.GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //instantiate jellybeans at regular intervals, give random initial speed/direction

        if (_left)
        {
            if (this.gameObject.transform.rotation.eulerAngles.z > _upperAngle)
            {
                _left = false;
            }

            this.gameObject.transform.Rotate(Vector3.forward, 0.5f);
        }
        else {
            if (this.gameObject.transform.rotation.eulerAngles.z < _lowerAngle) {
                _left = true;
            }

            this.gameObject.transform.Rotate(Vector3.forward, -0.5f);
        }

        if (Random.Range(0f, 1f) > 0.99) {
            Vector3 direction = _directionPoint.position.normalized;
            Debug.Log(direction);
            GameObject tempJellybean = Instantiate(_jellybean, this.gameObject.transform.position, Quaternion.identity);
            Rigidbody2D rb2d = tempJellybean.GetComponent<Rigidbody2D>();
            rb2d.AddForce(Vector2.one * _launchMagnitude);
        }
    }
}
