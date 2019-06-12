using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Score : MonoBehaviour
{
    public int _playerScore = 0;
    public int _maxScore;

    public GameObject _dispenser;
    public GameObject _spotlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerScore >= _maxScore)
        {
            EndLevel();
        }
    }

    public void EndLevel()
    {
        _dispenser.SetActive(false);
        _spotlight.SetActive(false);
        GameObject[] jellybeans = GameObject.FindGameObjectsWithTag("Jellybean");

        for (int i = 0; i < jellybeans.Length; i++)
        {
            Destroy(jellybeans[i]);
        }
    }
}
