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

    private int count = 0;

    private float timer = 0f;
    private bool canSpawn = false;
    private float respawnTimeDelay = 2f;

    private float initialY;
    private Animator animator;

    private void Awake()
    {
        initialY = transform.position.y;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CastleBlock"))
        {
            SetObjectInActive(false);

            Hide();
        }
    }

    private void Update()
    {
        if (canSpawn)
        {
            timer += Time.deltaTime;
            if (timer > respawnTimeDelay)
            {
                Spawn();
                timer = 0f;
                canSpawn = false;
            }
        }
    }

    public void ResetRespawnTimer()
    {
        count++;
        timer = 0f;
        canSpawn = true;
    }

    private void SetObjectInActive(bool value)
    {
        collider.enabled = value;
        renderers.ForEach(renderer => renderer.enabled = value);
    }

    private void Hide()
    {
        animator.SetTrigger("Hide");
    }

    private void Spawn()
    {
        transform.position = new Vector3(transform.position.x, initialY + 100 * count, transform.position.z);
        SetObjectInActive(true);
        animator.SetTrigger("Spawn");
    }
}
