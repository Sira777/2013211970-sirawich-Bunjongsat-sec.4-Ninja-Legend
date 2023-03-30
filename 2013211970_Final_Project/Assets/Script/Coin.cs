using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public GameObject pop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.playCoin();
            GamePlay.instance.getCoin(1);
            Instantiate(pop, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
