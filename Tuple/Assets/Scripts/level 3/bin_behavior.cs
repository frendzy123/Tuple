using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bin_behavior : MonoBehaviour
{
	public GameObject head;
    public Level3Score _playerScore;
    public GameObject _jellybean;
    public float minXMag;
    public float maxXMag;
    public float minYMag;
    public float maxYMag;
    public int _maxScore;

    public int _beanCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //store beans until triggered, release beans with random speed/direction
		//keep track of score (affects bin appearance? also scene end condition)
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jellybean")
        {
            GrabObjectGeneral grabObject = collision.gameObject.GetComponentInChildren<GrabObjectGeneral>();
            if (grabObject._dropped)
            {
                _beanCount++;
                Destroy(collision.gameObject);
                _playerScore._playerScore++;
            }
        }
    }

    public void Vommit()
    {
        int tempBeanCount = _beanCount;
        for (int i = 0; i < tempBeanCount; i++)
        {
            Vector3 direction = new Vector3(Random.Range(minXMag, maxXMag), Random.Range(minYMag, maxYMag), 0);
            GameObject tempJellybean = Instantiate(_jellybean, this.gameObject.transform.position, Quaternion.identity);
            Rigidbody2D rb2d = tempJellybean.GetComponent<Rigidbody2D>();
            rb2d.velocity = (direction);
            rb2d.angularVelocity = 40;
            _playerScore._playerScore--;
            _beanCount--;
        }
    }
}
