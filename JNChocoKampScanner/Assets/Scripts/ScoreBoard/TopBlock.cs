using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBlock : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D collider;
    [SerializeField]
    private List<Image> renderers = new List<Image>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CastleBlock"))
        {
            SetObjectInActive(false);

            StartCoroutine(MoveAndSpawn());
        }
    }

    private void SetObjectInActive(bool value)
    {
        collider.enabled = value;
        renderers.ForEach(renderer => renderer.enabled = value);
    }

    private IEnumerator MoveAndSpawn()
    {
        var animator = GetComponent<Animator>();
        animator.SetTrigger("Hide");

        yield return new WaitForSeconds(0.2f);
        
        transform.position = new Vector3(transform.position.x, transform.position.y + 100, transform.position.z);
        SetObjectInActive(true);
        animator.SetTrigger("Spawn");
    }
}
