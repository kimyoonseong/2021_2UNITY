using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Heal : MonoBehaviour
{
    private AudioSource Audio;
    public AudioClip HealSound;
    // Start is called before the first frame update
    void Start()
    {
        this.Audio = this.gameObject.AddComponent<AudioSource>();
        this.Audio.clip = this.HealSound;
        this.Audio.loop = false;
        //Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.01f);
            this.Audio.Play();
        }
    }
}
