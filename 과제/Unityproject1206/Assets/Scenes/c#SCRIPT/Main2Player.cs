using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Main2Player : MonoBehaviour
{
    public float speed;      // 캐릭터 움직임 스피드.
    public float jumpSpeed; // 캐릭터 점프 힘.
    public float rotationSpeed = 360f; // 회전 속도 지정
    public float gravity;    // 캐릭터에게 작용하는 중력.
    private CharacterController controller; // 현재 캐릭터가 가지고있는 캐릭터 컨트롤러 콜라이더.
    private Vector3 MoveDir;                // 캐릭터의 움직이는 방향.
    Animator animator;
    private AudioSource Audio;
    public AudioClip jumpSound;
    private Vector3 direction = Vector3.zero;
    public GameObject CAM;
    // Start is called before the first frame update
    void Start()
    {
        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        this.Audio = this.gameObject.AddComponent<AudioSource>();
        this.Audio.clip = this.jumpSound;
        this.Audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 캐릭터가 땅에 있는가?
        if (controller.isGrounded)
        {
            // 위, 아래 움직임 셋팅.
            Vector3 heading = transform.position - CAM.transform.position;
            heading.y = 0;
            heading = heading.normalized;
            direction = heading * Time.deltaTime * Input.GetAxis("Vertical");
            direction += Quaternion.Euler(0, 90, 0) * heading * Time.deltaTime * Input.GetAxis("Horizontal");
            direction = direction.normalized;


            Vector3 forward = Vector3.Slerp( // 메소드를 조합해 플레이어의 방향 변환
               transform.forward,
               direction,
               rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
            );
            transform.LookAt(transform.position + forward);
            /*
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (MoveDir.sqrMagnitude > 0.01f)
            {
                /*Vector3 forward = Vector3.Slerp( // 메소드를 조합해 플레이어의 방향 변환
                transform.forward,
                MoveDir,
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, MoveDir)
                );
                transform.LookAt(transform.position + forward);
                */
            if (Input.GetButton("Jump"))
            {
                direction.y = jumpSpeed;
                this.Audio.Play();
            }
        }
        else
            direction.y -= gravity * Time.deltaTime;


        controller.Move(direction * speed * Time.deltaTime);
        animator.SetFloat("Speed", controller.velocity.magnitude);

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "portal")
        {
            //iskey5 = false;
            //isportal = true;
            SceneManager.LoadScene("Success");
        }
    }
}
