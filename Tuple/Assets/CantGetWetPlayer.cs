using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantGetWetPlayer : MonoBehaviour
{
    public float hp = 10;

    TriggerVolumeObserver _trigVolObserver;
    // Start is called before the first frame update
    void Awake()
    {
        _trigVolObserver = this.GetComponent<TriggerVolumeObserver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_trigVolObserver.objectsInTriggerZone.Count == 0)
        {
            hp = Time.deltaTime;
        }
    }
}
