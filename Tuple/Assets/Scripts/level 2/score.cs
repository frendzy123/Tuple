using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public static bool isPosTriggered;
    public static bool isNegTriggered;
    public static float playerScore;

//testing
    public float scorecopy;
    public bool poscopy;
    public bool negcopy;
//testing

    public float incrementSpeed;
    public float decrementSpeed; //score decay speed, should be much less than incrementSpeed

    private float minScore = 0f;
    private float maxScore = 100f;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0f;
        isPosTriggered = false;
        isNegTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
//testing
        scorecopy = playerScore;
        poscopy = isPosTriggered;
        negcopy = isNegTriggered;
//testing

        if (playerScore >= maxScore) {
        	//trigger scene transition
        }
        else {
            if (isPosTriggered && isNegTriggered) {
                playerScore = playerScore + incrementSpeed*Time.deltaTime;
            }
            else {
                float decrementScore = playerScore - decrementSpeed*Time.deltaTime;
                if (decrementScore >= minScore) {
                    playerScore = decrementScore;
                }
            }
        }
    }
}
