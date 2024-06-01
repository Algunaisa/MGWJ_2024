using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        GetComponentInParent<JabaliMovement>().OnGroundTrigger.Invoke(true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        GetComponentInParent<JabaliMovement>().OnGroundTrigger.Invoke(false);
    }
}
