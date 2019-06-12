using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroAnimation : MonoBehaviour
{

    public GameObject _bus;
    public GameObject _peopleObject;
    public Animator _people;
    public Animator _zzz;
    public Vector3 _start;
    public Vector3 _end1;
    public Vector3 _end2;

    private bool _moveBus = false;
    private bool _moveBus2 = false;
    private float _movement = 0;
    private float _movement2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        _zzz.SetBool("asleep", true);
        StartCoroutine("WakingUp");
    }

    // Update is called once per frame
    void Update()
    {

        if (_moveBus)
        {
            if (_bus.transform.position.x < _end1.x)
            {
                _movement += 0.1f * Time.deltaTime;
                _bus.transform.position = Vector3.Lerp(_start, _end1, _movement);
            }
            else
            {
                _moveBus = false;
                StartCoroutine("BusWait");
            }
        }

        if (_moveBus2)
        {
            _movement2 += 0.1f * Time.deltaTime;
            _bus.transform.position = Vector3.Lerp(_end1, _end2, _movement2);
        }
    }

    IEnumerator WakingUp()
    {
        yield return new WaitForSeconds(10f);
        _zzz.SetBool("asleep", false);
        yield return new WaitForSeconds(1f);
        _people.SetBool("awake", true);
        yield return new WaitForSeconds(1f);
        _moveBus = true;
    }

    IEnumerator BusWait()
    {
        yield return new WaitForSeconds(2f);
        _peopleObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        _moveBus2 = true;
    }

    private void MoveBus(Vector3 start, Vector3 end)
    {
        _bus.transform.position = Vector3.Lerp(start, end, Time.deltaTime);

        if (_bus.transform.position.x < end.x) {
            MoveBus(start, end);
        }
    }
}
