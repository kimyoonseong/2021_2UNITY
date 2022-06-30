using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    Rigidbody myRigid;

    Vector3 playerPosition;
    private AudioSource aud;
    public AudioClip jumpSound;
    public float force = 400.0f;
    public float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        myRigid = GetComponent<Rigidbody>();
        this.aud = this.gameObject.AddComponent<AudioSource>();
        this.aud.clip = this.jumpSound;
        this.aud.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {

        playerPosition = this.transform.position;
        //�� ��ü�� �����̴� ��Ұ� ������ Rigidbody�� WASD �Ӹ� �ƴ϶�
        //Use gravity�� ����ؼ� �߷������� �Ǳ� ������
        //�߷¿� ���� ��ȭ�� ������ �ص־� �ϴ� ���� ������ ���� ��ġ�� ��� �����ؾ���.
        if (Input.GetButtonDown("Jump"))
        {
            this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1.0f, 0) * force);
            this.aud.Play();
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerPosition += Vector3.forward * moveSpeed * Time.deltaTime;
            //��ü�� ��ġ�� ���ŵǸ� �״��� Vector3.forward��� ������ǥ���� '��' ����, �ӵ�, �ð��� 60����1 �� ������ �� 
            //playerPosition�� �����ش�.

            myRigid.MovePosition(playerPosition);
            //���� movePosition���� ���� ���ŵ� ��ġ�� �̵��� ����.

        }
        if (Input.GetKey(KeyCode.S))
        {
            playerPosition += Vector3.left * moveSpeed * Time.deltaTime;

            myRigid.MovePosition(playerPosition);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerPosition -= Vector3.forward * moveSpeed * Time.deltaTime;

            myRigid.MovePosition(playerPosition);
        }
        if (Input.GetKey(KeyCode.W))
        {
            playerPosition -= Vector3.left * moveSpeed * Time.deltaTime;

            myRigid.MovePosition(playerPosition);
        }
    }
    private GUIStyle guiStyle = new GUIStyle();
    
    void OnGUI()
    {
        if (this.transform.position.y < -2.0f)
        { 
          // ȭ�鿡 '����'�̶�� ǥ��
            guiStyle.fontSize = 40;
            GUI.Label(new Rect(Screen.width / 2, 80, 100, 40), "����", guiStyle);
            guiStyle.normal.textColor = Color.red;
            if (Input.GetMouseButtonDown(0))
            { // ��Ŭ���Ǿ�����
                SceneManager.LoadScene("Main"); // Main scene �̵�
            }
        }
    }
}
