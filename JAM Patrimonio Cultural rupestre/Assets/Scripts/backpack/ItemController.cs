using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private Item itemData;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float gravity = 9f;
    public bool dropdown = false;


    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        DropDown();
    }
    void DropDown()
    {
        if (!dropdown) return;
        if (rb == null) return;
        rb.velocity += gravity * Time.fixedDeltaTime * Vector2.down;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (dropdown && other.gameObject.CompareTag("Ground"))
        {
            dropdown = false;
            rb.velocity = Vector2.zero;
        }
        // FIXME cada collider agrega un item, antes de que se destruya. 
        // Diferenciar colliders con tagnames?
        if (other.CompareTag("Player"))
        {
            Debug.Log(itemData.description);
            BagManager.Instance.AddItem(itemData);
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            JabaliMovement jm = other.gameObject.GetComponent<JabaliMovement>();
            jm.FromAnyStateToEat();
            Destroy(gameObject);
        }
    }

    private float IsOverGround()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down);
        return ray.distance;
    }
    public void ChangeItem(Item item)
    {
        itemData = item;
        spriteRenderer.sprite = item.sprite;
    }
}
