using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public Text timerText;
     float time=180;
     int currentTime;
    public static bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        //timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       
            time -= Time.deltaTime;
            currentTime = (int)time;
            timerText.text = "남은시간:" + currentTime;
            if(currentTime == 0)
            {
                SceneManager.LoadScene("Failure");
            }
    }
}
