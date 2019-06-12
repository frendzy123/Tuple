using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4Score : MonoBehaviour
{

    public float _playerScore = 0;
    public Animator _anim;

    private bool _locked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerScore >= 100 && !_locked)
        {
            _locked = true;
            StartCoroutine("Transition");
        }
    }

    IEnumerator Transition()
    {
        _anim.SetBool("transition", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Scenes/Outro");
    }
}
