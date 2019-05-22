using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyChainColliders : MonoBehaviour
{
    PlayerBody _srcBody;
    List<BoxCollider2D> _bodyChainColliders;

    public float _colHeight;
    // Start is called before the first frame update
    void Awake()
    {
        _srcBody = this.GetComponentInParent<PlayerBody>();
        _bodyChainColliders = new List<BoxCollider2D>();
        for (int i = 0; i < _srcBody.bodyControlsPoints.Count - 1; i++)
        {
            GameObject boxColObject = new GameObject("chain-box-" + i);
            boxColObject.transform.parent = this.transform;
            boxColObject.tag = "Body";
            BoxCollider2D collider = boxColObject.AddComponent<BoxCollider2D>();
            boxColObject.layer = LayerMask.NameToLayer("body_links");
            //collider.enabled = false;
            _bodyChainColliders.Add(collider);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _srcBody.bodyControlsPoints.Count - 1; i++)
        {
            Vector3 controlPoint1 = _srcBody.bodyControlsPoints[i].transform.position;
            Vector3 controlPoint2 = _srcBody.bodyControlsPoints[i + 1].transform.position;
            BoxCollider2D bc = _bodyChainColliders[i];
            bc.transform.position = 0.5f * (controlPoint1 + controlPoint2);
            Vector3 controlPtDiff = controlPoint2 - controlPoint1;
            Vector2 bcSize = bc.size;
            bcSize.y = _colHeight;
            bcSize.x = controlPtDiff.magnitude;
            bc.size = bcSize;
            bc.transform.right = controlPtDiff;
        }
    }
}
