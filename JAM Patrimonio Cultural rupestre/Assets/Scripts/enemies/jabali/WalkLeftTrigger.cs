using UnityEngine;

public class WalkLeftTrigger : MonoBehaviour
{
    JabaliMovement jabaliMovement;
    void Start()
    {
        jabaliMovement = GetComponentInParent<JabaliMovement>();
    }

    void Update()
    {
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // GetComponentInParent<JabaliMovement>().OnWalkTrigger?.Invoke(Vector2.left);
        if (other.gameObject.CompareTag("Ground"))
        {
            //GetComponentInParent<JabaliMovement>().OnWalkTrigger?.Invoke();
            jabaliMovement.OnWalkTrigger?.Invoke();
        }
    }
}
