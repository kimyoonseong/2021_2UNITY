using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public GameObject prefab = null;

    private AudioSource audio;
    public AudioClip jumpSound; // jump 음원
    public AudioClip BGMSound; // BGM 음원

    public Texture2D icon = null;
    public static string mes_text = "test";
    void Start()
    {
        // GameObject에 <AudioSource> component 추가.
        this.audio = this.gameObject.AddComponent<AudioSource>();
        // 반복 재생을 않도록 설정.
        this.audio.loop = false;
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2, 64, 64, 64), icon);
        GUI.Label(new Rect(Screen.width / 2, 128, 128, 32), mes_text);
    }
    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))//왼쪽버튼

        {
            Instantiate(prefab);
        }
    }*/
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Instantiate(prefab);
            // prefab변수에서 만들어진 GameObject를 가져옴.
            GameObject go = GameObject.Instantiate(this.prefab) as GameObject;
            // 가져온 GameObject의 설정을 변경.
            float rnd = Random.Range(-2.0f, 2.0f);
            go.transform.position = new Vector3(rnd, 2.0f, 2.0f);
        }



        if (Input.GetMouseButtonDown(0))
        {
            this.audio.clip = this.jumpSound;
            this.audio.Play(); // audio clip에 들어있는 음원을 재생.
        }
        if (Input.GetMouseButtonDown(1))
        {
            this.audio.clip = this.BGMSound;
            if (this.audio.isPlaying == false) // replay 중이 아니면
            {
                this.audio.Play(); // audio clip 음원을 재생.
            }
        }

    }

}
