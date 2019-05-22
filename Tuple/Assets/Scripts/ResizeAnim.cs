using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeAnim : MonoBehaviour
{

    public float _sizeX;
    public float _sizeY;
    public float _sizeZ;

    private SpriteRenderer _sprite;

    // Start is called before the first frame update
    void Start()
    {
        _sprite = this.transform.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _sprite.size = new Vector3(_sizeX, _sizeY, _sizeZ);
    }
}
