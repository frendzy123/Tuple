using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyLineRenderer : MonoBehaviour
{
    PlayerBody _srcBody;
    LineRenderer _lr;

    public PlayerControls _rightHeads;
    public PlayerControls _leftHeads;
    public float _startStretching;
    public float _stretchSideMultiplier;
    public float _stretchCenterMultiplier;

    [Range(0, 10)]
    public int _lrCornerSmoothness;

    [Range(0 , 10)]
    public int _lrCapSmoothness;

    void Awake()
    {
        _srcBody = this.GetComponentInParent<PlayerBody>();
        _lr = this.GetComponent<LineRenderer>();
        _lr.sortingOrder = 3;
        _lr.positionCount = _srcBody.bodyControlsPoints.Count;
        _lr.numCornerVertices = _lrCornerSmoothness;
        _lr.numCapVertices = _lrCapSmoothness;

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _srcBody.bodyControlsPoints.Count; i++)
        {
            Vector3 positions = _srcBody.bodyControlsPoints[i].transform.position;
            _lr.SetPosition(i, new Vector3(positions.x, positions.y, 0));
        }

        AdjustLine();
    }

    // Adjust the width of different segments of the line to give impression of tension and strech.
    private void AdjustLine() {
        float hypotenuse = Mathf.Sqrt(Mathf.Pow((_rightHeads.transform.position.x - _leftHeads.transform.position.x), 2) +
            Mathf.Pow((_rightHeads.transform.position.y - _leftHeads.transform.position.y), 2));

        if (hypotenuse > _startStretching) {
            AnimationCurve curve = new AnimationCurve();

            float keyScalingSides = _stretchSideMultiplier * (hypotenuse - _startStretching);
            float keyCenterSides = _stretchCenterMultiplier * (hypotenuse - _startStretching);

            curve.AddKey(0.0f, 0.4f);
            curve.AddKey(0.25f, 0.4f - keyScalingSides);
            curve.AddKey(0.5f, 0.4f - keyCenterSides);
            curve.AddKey(0.75f, 0.4f - keyScalingSides);
            curve.AddKey(1.0f, 0.4f);

            _lr.widthCurve = curve;
            _lr.widthMultiplier = 1.0f;
        }
    }
}
