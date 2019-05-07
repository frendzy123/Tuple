using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_movement : MonoBehaviour
{
	public GameObject _top_door;
	public GameObject _bottom_door;

	public float _top_y1;
	public float _top_y2;
	public float _bottom_y1;
	public float _bottom_y2;

	private Vector3 _top_pos1;
	private Vector3 _top_pos2;
	private Vector3 _bottom_pos1;
	private Vector3 _bottom_pos2;

	public float speed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
    	_top_pos1 = new Vector3(0, _top_y1, -1);
    	_top_pos2 = new Vector3(0, _top_y2, -1);
    	_bottom_pos1 = new Vector3(0, _bottom_y1, -1);
    	_bottom_pos2 = new Vector3(0, _bottom_y2, -1);
    }

    // Update is called once per frame
    void Update()
    {
    	_top_door.transform.position = Vector3.Lerp(_top_pos1, _top_pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    	_bottom_door.transform.position = Vector3.Lerp(_bottom_pos1, _bottom_pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
