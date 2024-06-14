using UnityEngine;

public class WalkTrigger : MonoBehaviour
{
    public Vector2 direction = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log("Salgo R");
        // GetComponentInParent<JabaliMovement>().OnWalkTrigger?.Invoke(Vector2.right);
        if (other.gameObject.CompareTag("Ground"))
        {
            GetComponentInParent<JabaliMovement>().OnWalkTrigger?.Invoke();
        }
    }
}
