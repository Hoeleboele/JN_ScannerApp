using UnityEngine;

public class TopBlock : MonoBehaviour
{
    private bool canCollide = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canCollide)
        {
            if (collision.gameObject.CompareTag("CastleBlock"))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 400, transform.position.z);
                canCollide = false;
            }
        }
    }

    public void EnableCollision()
    {
        canCollide = true;
    }
}
