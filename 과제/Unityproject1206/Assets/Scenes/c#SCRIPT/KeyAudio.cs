using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAudio : MonoBehaviour
{
    private AudioSource CollisionSound;
    public AudioClip CrashSound;
    // Start is called before the first frame update
    void Start()
    {
        this.CollisionSound = this.gameObject.AddComponent<AudioSource>();
        this.CollisionSound.clip = this.CrashSound;
        this.CollisionSound.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "KEY")
        {
            this.CollisionSound.Play();

        }
    }
}
