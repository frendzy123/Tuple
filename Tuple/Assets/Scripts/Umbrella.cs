using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Umbrella : MonoBehaviour
{

    public Slider _slider;
    [Range(0f, 10f)]
    public float _initialSpeed;
    [Range(0f, 10f)]
    public float _speedRange;
    [Range(0f, 1f)]
    public float _speedChangeChance;

    private Rigidbody2D _rb2d;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = this.GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per Physics cycle
    void FixedUpdate()
    {

        if (_slider.value >= 0f && _slider.value < 0.35f) {

            if (Random.Range(0f, 1f) <= _speedChangeChance) {
                _initialSpeed = Mathf.Sign(_initialSpeed) * Random.Range(1f, _speedRange);
            }

            if (_rb2d.position.x <= -5.5 || _rb2d.position.x >= 5.5)
            {
                _initialSpeed = -1 * _initialSpeed;
            }

            Vector3 velocity = new Vector3(_initialSpeed, 0, 0);
            Vector3 position = new Vector3(_rb2d.position.x, _rb2d.position.y, 0);
            _rb2d.MovePosition(position + velocity * Time.fixedDeltaTime);
        }
        else if (_slider.value >= 0.35f && _slider.value < 0.65f) {

        }
        else {

        }
    }
}
