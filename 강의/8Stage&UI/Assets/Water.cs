using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Water : MonoBehaviour
{
    public Slider healthBarSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Water" && healthBarSlider.value > 0)
        {
            healthBarSlider.value += .011f;
            //Destroy(gameObject);
        }
        
    }
}
