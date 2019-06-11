using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispense : MonoBehaviour
{
    public GameObject _jellybean;
    public float _launchMagnitude;
    public int _upperAngle;
    public int _lowerAngle;
    public int _spawnProbability;
    public int _maxDelay;
    public int _minDelay;

    private bool _left = false;
    private bool _dispense = true;

    // Start is called before the first frame update
    void Start()
    {
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
        else
        {
            if (this.gameObject.transform.rotation.eulerAngles.z < _lowerAngle) {
                _left = true;
            }

            this.gameObject.transform.Rotate(Vector3.forward, -0.5f);
        }

        if (Random.Range(0, 10) > _spawnProbability && _dispense) {
            float xMag = 1f;
            float yMag = 1f;
            float angle = 0f;

            if (this.gameObject.transform.rotation.eulerAngles.z >= 180)
            {
                 xMag = -1f;
                // yMag = -1f;
                angle = ((this.gameObject.transform.rotation.eulerAngles.z - 180) * Mathf.PI) / 180;
            }
            else {
               // xMag = -1f;
               // yMag = 1f;
                angle = ((180 - this.gameObject.transform.rotation.eulerAngles.z) * Mathf.PI) / 180;
            }
            
            Vector3 direction = new Vector3(xMag*Mathf.Sin(angle), yMag*Mathf.Cos(angle), 0);
            GameObject tempJellybean = Instantiate(_jellybean, this.gameObject.transform.position, Quaternion.identity);
            Rigidbody2D rb2d = tempJellybean.GetComponent<Rigidbody2D>();
            rb2d.velocity = (direction * _launchMagnitude);
            rb2d.angularVelocity = 40;
            _dispense = false;
            StartCoroutine("delay");
        }
    }

    IEnumerator delay() {
        yield return new WaitForSeconds(_maxDelay);
        if (_maxDelay > _minDelay) {
            _maxDelay--;
        }
        _dispense = true;
    }
}
