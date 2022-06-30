using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float jumpPower;
    private AudioSource audio;
    public AudioClip jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            this.audio.Play();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        SceneManager.LoadScene("Main");
    }
}
