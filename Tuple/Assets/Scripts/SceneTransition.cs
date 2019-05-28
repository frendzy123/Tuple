using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneTransition : MonoBehaviour
{
    public string _nextLevel;
    public Animator _anim;

    private bool _leftHeadReady = false;
    private bool _rightHeadReady = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "RightHead")
        {
            _rightHeadReady = true;
        }

        if (collision.gameObject.name == "LeftHead")
        {
            _leftHeadReady = true;
        }

        if (_rightHeadReady && _leftHeadReady)
        {
            StartCoroutine("Transition");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "RightHead")
        {
            _rightHeadReady = false;
        }

        if (collision.gameObject.name == "LeftHead")
        {
            _leftHeadReady = false;
        }
    }

    IEnumerator Transition()
    {
        _anim.SetBool("ExitLevel", true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(_nextLevel);
    }
}
