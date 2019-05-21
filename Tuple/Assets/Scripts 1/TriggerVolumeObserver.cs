using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolumeObserver : MonoBehaviour
{

    public List<string> tagFilter = new List<string>();
    public List<GameObject> objectsInTriggerZone = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool okToAdd = !objectsInTriggerZone.Contains(collision.gameObject);
        okToAdd &= tagFilter.Count == 0 || tagFilter.Contains(collision.gameObject.tag);
        if (okToAdd)
        {
            objectsInTriggerZone.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectsInTriggerZone.Remove(collision.gameObject);
    }
}
