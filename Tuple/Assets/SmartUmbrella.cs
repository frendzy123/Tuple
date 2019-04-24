using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartUmbrella : MonoBehaviour
{
    public int _nPlayerUnderneathMe = 0;
    TriggerVolumeObserver _trigVolObserver;
    // Start is called before the first frame update
    void Awake()
    {
        _trigVolObserver = this.gameObject.AddComponent<TriggerVolumeObserver>();
        _trigVolObserver.tagFilter.Add("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _nPlayerUnderneathMe = _trigVolObserver.objectsInTriggerZone.Count;
    }
}
