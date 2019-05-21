using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terminal : MonoBehaviour
{
    public GameObject _leftHead;
    public GameObject _rightHead;
    public float _maxIntensity;

    private Light _pointLight;
    // Start is called before the first frame update
    void Start()
    {
        _pointLight = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float leftHeadDistance = Vector3.Distance(_leftHead.transform.position, this.gameObject.transform.position);
        float rightHeadDistance = Vector3.Distance(_rightHead.transform.position, this.gameObject.transform.position);

        float minDistance = Mathf.Min(leftHeadDistance, rightHeadDistance);

        _pointLight.intensity = Mathf.Clamp(_maxIntensity / minDistance, 0, _maxIntensity);
    }

    //if different colored aura lights implemented, need public static int to store current state for terminals (and heads?)
    //need Lights with preset colors and maxintensities
    //vibration to indicate wrong color if latched on during color change
}