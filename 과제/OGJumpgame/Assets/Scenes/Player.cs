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
        //이 물체를 움직이는 요소가 오로지 Rigidbody의 WASD 뿐만 아니라
        //Use gravity를 사용해서 중력이적용 되기 때문에
        //중력에 의한 변화도 갱신을 해둬야 하는 이유 때문에 실제 위치를 계속 적용해야함.
        if (Input.GetButtonDown("Jump"))
        {
            this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1.0f, 0) * force);
            this.aud.Play();
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerPosition += Vector3.forward * moveSpeed * Time.deltaTime;
            //물체의 위치가 갱신되면 그다음 Vector3.forward라는 세계좌표기준 '앞' 값과, 속도, 시간의 60분의1 을 곱해준 후 
            //playerPosition에 뎌해준다.

            myRigid.MovePosition(playerPosition);
            //이제 movePosition덕에 새로 갱신된 위치로 이동될 것임.

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
          // 화면에 '실패'이라고 표시
            guiStyle.fontSize = 40;
            GUI.Label(new Rect(Screen.width / 2, 80, 100, 40), "실패", guiStyle);
            guiStyle.normal.textColor = Color.red;
            if (Input.GetMouseButtonDown(0))
            { // 좌클릭되었으면
                SceneManager.LoadScene("Main"); // Main scene 이동
            }
        }
    }
}
