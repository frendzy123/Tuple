using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Umbrella : MonoBehaviour
{

    [Range(0f, 10f)]
    public float _initialSpeed;
    [Range(0f, 10f)]
    public float _speedRange;
    [Range(0f, 1f)]
    public float _speedChangeChance;

    private Slider _slider;
    private Rigidbody2D _rb2d;
    private TriggerVolumeObserver _triggerVolumeObserver;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        _rb2d = this.GetComponent<Rigidbody2D>();
        _triggerVolumeObserver = this.GetComponent<TriggerVolumeObserver>();
    }

    // FixedUpdate is called once per Physics cycle
    void FixedUpdate()
    {

        if (Random.Range(0f, 1f) <= _speedChangeChance) {
                //Mathf.Sign(_initialSpeed) * <== Used to remove any unpredictable motion. BUT WE WANT UNPREDICTABLE MOTION!!
            _initialSpeed = Random.Range(1f, _speedRange);
        }

        if (_rb2d.position.x <= -5.5 || _rb2d.position.x >= 5.5)
        {
            _initialSpeed = -1 * _initialSpeed;
        }

        Vector3 velocity = new Vector3(_initialSpeed, 0, 0);
        Vector3 position = new Vector3(_rb2d.position.x, _rb2d.position.y, 0);
        _rb2d.MovePosition(position + velocity * Time.fixedDeltaTime);

        if (_slider.value >= 0 && _slider.value < 0.35f)
        {
            if (_triggerVolumeObserver.objectsInTriggerZone.Count == 2)
            {
                _slider.value += 0.05f * Time.deltaTime;
            }
        }
    }
}
