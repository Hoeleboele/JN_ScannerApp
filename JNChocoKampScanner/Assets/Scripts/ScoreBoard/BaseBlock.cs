using UnityEngine;

public class BaseBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CastleBlock"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            collision.gameObject.AddComponent<BaseBlock>();
            gameObject.GetComponent<BaseBlock>().enabled = false;
        }
    }
}
