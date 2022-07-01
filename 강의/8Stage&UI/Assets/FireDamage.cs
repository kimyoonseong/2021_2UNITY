using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireDamage : MonoBehaviour
{
    public Slider healthBarSlider;
    public Text gameOverText;
    private bool isGameOver = false;
    void Start()
    {
        gameOverText.enabled = false;
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Fire" && healthBarSlider.value > 0)
        {
            healthBarSlider.value -= .011f;
        }
        else if(healthBarSlider.value==0)
        {
            isGameOver = true;
            gameOverText.enabled = true;
        }
    }

}
