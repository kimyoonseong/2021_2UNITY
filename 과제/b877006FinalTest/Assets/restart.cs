using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class restart : MonoBehaviour
{
    public Text timerText;
    private int currentTime;
    private float time = 10;
    //public GameObject InfoPanel;
    // Start is called before the first frame update
    void Start()
    {
        //InfoPanel.SetActive(false);
        timerText = GetComponent<Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ClickStartButton()
    {
        time += 5;
        SceneManager.LoadScene("Main"); // Main scene ¿Ãµø  
    }
}
