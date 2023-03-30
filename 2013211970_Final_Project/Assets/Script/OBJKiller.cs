using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJKiller : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GamePlay.instance.gameOver();
        }
    }
}
