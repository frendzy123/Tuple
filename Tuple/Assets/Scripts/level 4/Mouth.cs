using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{

    public Level4Score _playerScore;
    public Sprite neutral;
    public Sprite smile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerScore._playerScore > 35f && _playerScore._playerScore < 80f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = neutral;
        }
        else if (_playerScore._playerScore > 80f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = smile;
        }
    }
}
