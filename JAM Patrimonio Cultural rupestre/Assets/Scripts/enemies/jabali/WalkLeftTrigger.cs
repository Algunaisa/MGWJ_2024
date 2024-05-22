using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkLeftTrigger : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // GetComponentInParent<JabaliMovement>().OnWalkTrigger?.Invoke(Vector2.left);
        GetComponentInParent<JabaliMovement>().OnWalkTrigger?.Invoke();
    }
}
