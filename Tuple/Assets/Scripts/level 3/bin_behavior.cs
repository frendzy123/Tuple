using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bin_behavior : MonoBehaviour
{
	public GameObject head;
    public Level3Score _playerScore;
    public GameObject _jellybean;
    public Animator _tongue;
    public float minXMag;
    public float maxXMag;
    public float minYMag;
    public float maxYMag;

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
                grabObject._dropped = false;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                _beanCount++;
                StartCoroutine("TongueIn", collision.gameObject);
                _playerScore._playerScore++;
            }
            else if (grabObject._grabbed)
            {
                _tongue.SetBool("open", true);
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

    IEnumerator TongueIn(GameObject gameObject) {
        yield return new WaitForSeconds(1f);
        _tongue.SetBool("open", false);
        _tongue.SetBool("close", true);
        Destroy(gameObject);
    }
}
