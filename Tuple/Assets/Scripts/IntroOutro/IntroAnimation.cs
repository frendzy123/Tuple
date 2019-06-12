using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAnimation : MonoBehaviour
{

    public Animator _people;
    public Animator _zzz;
    public Animator _transition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("FallAsleep");
    }

    IEnumerator FallAsleep()
    {
        yield return new WaitForSeconds(15f);
        _people.SetBool("asleep", true);
        yield return new WaitForSeconds(2f);
        _zzz.SetBool("asleep", true);
        yield return new WaitForSeconds(6f);
        _transition.SetBool("transition", true);
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Scenes/Level1");
    }
}
