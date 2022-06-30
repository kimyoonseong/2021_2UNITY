using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public GameObject prefab = null;

    private AudioSource audio;
    public AudioClip jumpSound; // jump ����
    public AudioClip BGMSound; // BGM ����

    public Texture2D icon = null;
    public static string mes_text = "test";
    void Start()
    {
        // GameObject�� <AudioSource> component �߰�.
        this.audio = this.gameObject.AddComponent<AudioSource>();
        // �ݺ� ����� �ʵ��� ����.
        this.audio.loop = false;
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2, 64, 64, 64), icon);
        GUI.Label(new Rect(Screen.width / 2, 128, 128, 32), mes_text);
    }
    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))//���ʹ�ư

        {
            Instantiate(prefab);
        }
    }*/
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Instantiate(prefab);
            // prefab�������� ������� GameObject�� ������.
            GameObject go = GameObject.Instantiate(this.prefab) as GameObject;
            // ������ GameObject�� ������ ����.
            float rnd = Random.Range(-2.0f, 2.0f);
            go.transform.position = new Vector3(rnd, 2.0f, 2.0f);
        }



        if (Input.GetMouseButtonDown(0))
        {
            this.audio.clip = this.jumpSound;
            this.audio.Play(); // audio clip�� ����ִ� ������ ���.
        }
        if (Input.GetMouseButtonDown(1))
        {
            this.audio.clip = this.BGMSound;
            if (this.audio.isPlaying == false) // replay ���� �ƴϸ�
            {
                this.audio.Play(); // audio clip ������ ���.
            }
        }

    }

}
