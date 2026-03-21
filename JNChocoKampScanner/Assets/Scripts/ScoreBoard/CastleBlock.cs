using UnityEngine;

public class CastleBlock : MonoBehaviour
{
    private const float speed = 1000f;
    [SerializeField]
    private bool canMove;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            var pos = transform.position;
            pos.y -= speed * Time.fixedDeltaTime;

            //move rigidbody down
            rb.MovePosition(pos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CastleBlock") && canMove)
        {
            canMove = false;
            Debug.Log("nolog");
            transform.position = collision.gameObject.transform.position + new Vector3(0,100,0);
        }
    }
}