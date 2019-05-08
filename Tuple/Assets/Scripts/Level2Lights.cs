using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Lights : MonoBehaviour
{

    public GameObject _leftHead;
    public GameObject _rightHead;

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

        _pointLight.intensity = Mathf.Clamp(5 / minDistance, 0, 5);

    }
}
