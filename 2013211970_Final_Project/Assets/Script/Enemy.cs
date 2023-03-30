using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 2f;
    private Rigidbody2D rb;
    public float direction = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(enemySpeed*direction,rb.velocity.y);
    }

    void FilpSprite()
    {
        direction *= -1;
        transform.localScale = new Vector2(direction,1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ground") && !collision.CompareTag("Player"))
        {
            FilpSprite();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            FilpSprite();
        }
    }
}
