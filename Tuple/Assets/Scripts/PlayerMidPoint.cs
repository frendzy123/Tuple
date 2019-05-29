using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMidPoint : MonoBehaviour
{

    public GameObject _leftHead;
    public GameObject _rightHead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = (_leftHead.transform.position.x + _rightHead.transform.position.x) / 2;
        float y = (_leftHead.transform.position.y + _rightHead.transform.position.y) / 2;

        this.gameObject.transform.position = new Vector3(x, y, 0);
    }
}
