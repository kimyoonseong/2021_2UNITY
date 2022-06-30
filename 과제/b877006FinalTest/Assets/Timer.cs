using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    private Text timerText;
    private float time=10;
    private int currentTime;
    public static bool stop = false;
    public Text gameOverText;
    private bool isGameOver = false;
    public GameObject InfoPanel;
    public Button gameOverButton;
    // Start is called before the first frame update
    void Start()
    {
        gameOverButton.enabled = false;
        gameOverText.enabled = false;
        timerText = GetComponent<Text>();
        InfoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (stop)
        //{
            time -= Time.deltaTime;
            currentTime = (int)time;
            timerText.text = "Timer :" + currentTime;
        //}
        if (currentTime == 0)
        {
            isGameOver = true;
            gameOverText.enabled = true;
            //SceneManager.LoadScene("Fail");
            InfoPanel.SetActive(true);
            gameOverButton.enabled = true;
        }
    }
}
