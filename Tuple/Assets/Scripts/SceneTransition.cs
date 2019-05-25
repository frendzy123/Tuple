using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Scene _nextLevel;

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
            SceneManager.LoadScene(_nextLevel.path);
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
}
