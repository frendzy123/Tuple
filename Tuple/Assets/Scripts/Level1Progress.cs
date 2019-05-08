using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Level1Progress : MonoBehaviour
{

    public DigitalRuby.RainMaker.RainScript2D _rainControl;
    public SpriteRenderer _lightBackground;
    public SpriteRenderer _lightFlowers;
    public GameObject _umbrella;
    public GameObject _umbrellaSpawn;
    public float _rainIntensityRate;
    public float _rainChangeRate;
    public float _alphaChangeRate;
    public float _dayChangeRate;


    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fade");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Fade()
    {
        if (_lightBackground.color.a <= 0)
        {

            GameObject umbrella = Instantiate(_umbrella, _umbrellaSpawn.transform.position, Quaternion.identity);
            umbrella.GetComponent<Rigidbody2D>().AddForce(new Vector3(450, -0.5f, 0));
            StartCoroutine("Rain");
        }
        else
        {
            Color newColor = new Color(_lightBackground.color.r, _lightBackground.color.g, _lightBackground.color.b, _lightBackground.color.a - _alphaChangeRate);
            _lightBackground.color = newColor;
            _lightFlowers.color = newColor;
            yield return new WaitForSeconds(_dayChangeRate);
            StartCoroutine("Fade");
        }
    }

    IEnumerator Rain()
    {
        if (_rainControl.RainIntensity >= 1)
        {


        }
        else
        {
            _rainControl.RainIntensity += _rainIntensityRate;
            yield return new WaitForSeconds(_rainChangeRate);
            StartCoroutine("Rain");
        }
    }

    IEnumerator FadeIn()
    {
        if (_lightBackground.color.a >= 1)
        {

            GameObject umbrella = Instantiate(_umbrella, _umbrellaSpawn.transform.position, Quaternion.identity);
            umbrella.GetComponent<Rigidbody2D>().AddForce(new Vector3(450, -0.5f, 0));
            StartCoroutine("Rain");
        }
        else
        {
            Color newColor = new Color(_lightBackground.color.r, _lightBackground.color.g, _lightBackground.color.b, _lightBackground.color.a - _alphaChangeRate);
            _lightBackground.color = newColor;
            _lightFlowers.color = newColor;
            yield return new WaitForSeconds(_dayChangeRate);
            StartCoroutine("Fade");
        }
    }
}
