using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthSlider : MonoBehaviour
{
    public Slider healthBarSlider;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
            //healthBarSlider.value -= .001f;
            if (healthBarSlider.value == 0)
            {
                SceneManager.LoadScene("Failure");
            }
        
    }
    void OnTriggerStay(Collider collision)
    {
        //if (collision.gameObject.tag == "Enemy" && healthBarSlider.value > 0)
        //{
        //    healthBarSlider.value -= .111f;
        //}
        if (collision.gameObject.tag == "Health")
        {
            healthBarSlider.value += 1f;
            //Destroy(gameObject);
        }
        if (collision.gameObject.tag == "BigHealth")
        {
            healthBarSlider.value += 1f;
            //Destroy(gameObject);
        }
        if (healthBarSlider.value <= 0)
        {
            SceneManager.LoadScene("Failure");
        }

    }
    
    //private void OnCollisionEnter(Collision other) 
    //{
    //    Debug.Log("Collision");
    //    if (other.gameObject.tag == "Enemy" && healthBarSlider.value > 0)
    //    {
    //        healthBarSlider.value -= .111f;
    //    }
       
    //}
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            healthBarSlider.value -= .111f;

        }
    }
}
