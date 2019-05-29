using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnTrigger : MonoBehaviour
{

    public EdgeCollider2D _col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "interactable")
        {
            StartCoroutine("EnableCollider"); ;
        }
    }

    IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(1.0f);
        _col.enabled = true;
    }
}
