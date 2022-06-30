using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class damagebutton : MonoBehaviour
{
    public GameObject InfoPanel;
    public Button gameOverButton;
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        gameOverButton.enabled = false;
        InfoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            isGameOver = true;
            gameOverButton.enabled = true;
            InfoPanel.SetActive(true);
        }
    }
}
