using UnityEngine;

public class CastleBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //on collision with other castleblock stop moving
        if (collision.gameObject.CompareTag("CastleBlock"))
        {
            GetComponent<Rigidbody2D>().linearVelocityY = 0;
        }
    }
}