using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Level1Progress : MonoBehaviour
{
    public GameObject _umbrella;

    private Slider _slider;
    private GameObject[] _umbrellas = new GameObject[2];
    private bool _spawned1 = false;
    private bool _spawned2 = false;

    // Start is called before the first frame update
    void Start()
    {
        _slider = this.GetComponent<Slider>();
        _umbrellas[0] = null;
        _umbrellas[1] = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (_slider.value < 0.35f && _slider.value >= 0 && !_spawned1)
        {
            Vector3 position = new Vector3(0, 2.2742f, 0);
            _umbrellas[0] = Instantiate(_umbrella, position, Quaternion.identity);
            _spawned1 = true;
        }
        else if (_slider.value < 0.65f && _slider.value >= 0.35f && !_spawned2)
        {
            Vector3 position = new Vector3(0, 2.2742f, 0);
            _umbrellas[1] = Instantiate(_umbrella, position, Quaternion.identity);
            _spawned2 = true;
        }
    }
}
