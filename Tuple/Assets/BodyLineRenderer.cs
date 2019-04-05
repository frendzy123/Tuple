using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyLineRenderer : MonoBehaviour
{
    PlayerBody _srcBody;
    LineRenderer _lr;

    void Awake()
    {
        _srcBody = this.GetComponentInParent<PlayerBody>();
        _lr = this.GetComponent<LineRenderer>();
        //Vector3[] intialPositions = new Vector3[_srcBody.bodyControlsPoints.Count];
        //_srcBody
        _lr.positionCount = _srcBody.bodyControlsPoints.Count;
        //_lr.SetPositions(intialPositions);

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _srcBody.bodyControlsPoints.Count; i++)
        {
            _lr.SetPosition(i, _srcBody.bodyControlsPoints[i].transform.position);
        }
    }
}
