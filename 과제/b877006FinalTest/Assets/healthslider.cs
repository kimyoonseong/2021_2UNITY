using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class healthslider : MonoBehaviour
{
    public Slider healthBarSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (healthBarSlider.value == 0)
        {
            SceneManager.LoadScene("Fail");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarSlider.value == 0)
        {
            SceneManager.LoadScene("Fail");
        }
    }
    
}
