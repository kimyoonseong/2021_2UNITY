using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    //public GameObject InfoPanel;
    // Start is called before the first frame update
    void Start()
    {
        //InfoPanel.SetActive(false);
    }

    

    public void Closeinfo()
    {
        //InfoPanel.SetActive(false);
    }
    public void ClickStartButton() 
    {
        
        SceneManager.LoadScene("Main"); // Main scene ¿Ãµø  
    }
}
