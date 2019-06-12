using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMovement : MonoBehaviour
{

    public GameObject _head;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.right = _head.transform.position - this.gameObject.transform.position;
    }

    //
}
