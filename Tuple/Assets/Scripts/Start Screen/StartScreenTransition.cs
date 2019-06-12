using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenTransition : MonoBehaviour
{

    public Animator _animator;
    public PlayerControls _head1;
    public PlayerControls _head2;

    private string _nextScenePath = "Scenes/Opening";
    private bool _ready = false;
    private bool _locked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_ready)
        {
            _ready = false;
            _locked = true;
            StartCoroutine("Anim");
        }
        else if (_head1.IsGrabbing() || _head2.IsGrabbing() && !_locked)
        {
            _ready = true;
        }
        else if (Input.anyKeyDown && !_locked)
        {
            _ready = true;
        }
    }

    IEnumerator Anim()
    {
        _animator.SetBool("transition", true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(_nextScenePath);
    }
}
