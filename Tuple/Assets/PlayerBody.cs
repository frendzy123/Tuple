using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public List<BodyCollision> bodyControlsPoints = new List<BodyCollision>(); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Set Up List")]
    void SetUpList()
    {
        this.GetComponentsInChildren<BodyCollision>(bodyControlsPoints);
    }
}
