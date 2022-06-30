using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyDamage : MonoBehaviour
{
    public Text gameOverText;
   // public Button gameOverButton;
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.enabled = false;
        //gameOverButton.enabled = false;
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
            gameOverText.enabled = true;
            //gameOverButton.enabled = true;
        }
    }
}
