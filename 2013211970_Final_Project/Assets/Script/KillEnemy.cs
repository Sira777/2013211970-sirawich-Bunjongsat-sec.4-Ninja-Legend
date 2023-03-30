using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public GameObject enemy;
    public Rigidbody2D rbPlayer;

    public GameObject puff;

    private void Awake()
    {
        rbPlayer = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.playHit();
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x,5);
            Instantiate(puff,transform.position,transform.rotation);
            enemy.SetActive(false);
        }
    }
}
