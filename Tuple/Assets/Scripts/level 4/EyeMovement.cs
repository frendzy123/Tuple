﻿using System.Collections;
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
        // Mouse Implementation
        Vector3 target =  _head.transform.position - this.transform.position;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = 2 * target.normalized;
    }

    //
}
