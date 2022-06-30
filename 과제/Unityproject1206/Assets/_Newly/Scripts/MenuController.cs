using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuObject.activeSelf)
            {
                Time.timeScale = 0f;
                menuObject.SetActive(true);
            }
            else
            {
                ContinueGame();
            }
        }
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        menuObject.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameObject.scene.name);
    }

    public void ExitGame()
    {
        //Application.Quit();
        Time.timeScale = 1f;
        SceneManager.LoadScene("title");
    }
}
