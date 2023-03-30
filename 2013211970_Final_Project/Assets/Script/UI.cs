using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UI : MonoBehaviour
{
    public TextMeshProUGUI text_HP;
    public TextMeshProUGUI text_Coin;

    public GameObject panel;
    public void UpdateHP()
    {
        text_HP.text = PlayerMovement.instance.hp.ToString();
    }
    public void UpdateCoin()
    {
        text_Coin.text = GamePlay.instance.coin.ToString();
    }
    public void ShowMenu()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }
    public void HideMenu()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.instance.playGUI();
            ShowMenu();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHP();
        UpdateCoin();
        PauseGame();
    }
}
