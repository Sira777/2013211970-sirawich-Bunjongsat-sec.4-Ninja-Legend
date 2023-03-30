using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip coin;
    public AudioClip hit;
    public AudioClip enemyHit;
    public AudioClip win;
    public AudioClip gui;

    private AudioSource audioSource;

    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();   
    }

    public void playSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    public void playJump(){playSound(jump);}
    public void playCoin() { playSound(coin);}
    public void playHit() { playSound(hit); }
    public void playenemyHit() { playSound(enemyHit); }
    public void playWin() { playSound(win); }
    public void playGUI() { playSound(gui); }
}
