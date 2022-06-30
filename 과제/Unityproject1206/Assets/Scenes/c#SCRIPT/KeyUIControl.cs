using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUIControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Text CountText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountText.text = "¿­¼è: " + GameObject.Find("Player").GetComponent<Player2>().keycount + "/5";
    }
}
