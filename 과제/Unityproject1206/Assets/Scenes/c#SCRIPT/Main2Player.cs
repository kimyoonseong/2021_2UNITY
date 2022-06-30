using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Main2Player : MonoBehaviour
{
    public float speed;      // ĳ���� ������ ���ǵ�.
    public float jumpSpeed; // ĳ���� ���� ��.
    public float rotationSpeed = 360f; // ȸ�� �ӵ� ����
    public float gravity;    // ĳ���Ϳ��� �ۿ��ϴ� �߷�.
    private CharacterController controller; // ���� ĳ���Ͱ� �������ִ� ĳ���� ��Ʈ�ѷ� �ݶ��̴�.
    private Vector3 MoveDir;                // ĳ������ �����̴� ����.
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
        // ���� ĳ���Ͱ� ���� �ִ°�?
        if (controller.isGrounded)
        {
            // ��, �Ʒ� ������ ����.
            Vector3 heading = transform.position - CAM.transform.position;
            heading.y = 0;
            heading = heading.normalized;
            direction = heading * Time.deltaTime * Input.GetAxis("Vertical");
            direction += Quaternion.Euler(0, 90, 0) * heading * Time.deltaTime * Input.GetAxis("Horizontal");
            direction = direction.normalized;


            Vector3 forward = Vector3.Slerp( // �޼ҵ带 ������ �÷��̾��� ���� ��ȯ
               transform.forward,
               direction,
               rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
            );
            transform.LookAt(transform.position + forward);
            /*
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (MoveDir.sqrMagnitude > 0.01f)
            {
                /*Vector3 forward = Vector3.Slerp( // �޼ҵ带 ������ �÷��̾��� ���� ��ȯ
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
