using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float speed;      // ĳ���� ������ ���ǵ�.
    public float jumpSpeed; // ĳ���� ���� ��.
    public float rotationSpeed = 360f; // ȸ�� �ӵ� ����
    public float gravity;    // ĳ���Ϳ��� �ۿ��ϴ� �߷�.
    private CharacterController controller; // ���� ĳ���Ͱ� �������ִ� ĳ���� ��Ʈ�ѷ� �ݶ��̴�.
    private Vector3 MoveDir;                // ĳ������ �����̴� ����.
    Animator animator;

    //public Button gameOverText;
    //private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        //gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (controller.isGrounded)
        {
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (MoveDir.sqrMagnitude > 0.01f)
            {
                Vector3 forward = Vector3.Slerp( // �޼ҵ带 ������ �÷��̾��� ���� ��ȯ
                    transform.forward,
                    MoveDir,
                    rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, MoveDir)
            );
                transform.LookAt(transform.position + forward);

            }
            // ���͸� ���� ��ǥ�� ���ؿ��� ���� ��ǥ�� �������� ��ȯ�Ѵ�. �������� �̹���
            //MoveDir = transform.TransformDirection(MoveDir);

            //���ǵ� ����.��������

           // MoveDir *= speed;

            //ĳ���� ����
            if (Input.GetButton("Jump"))
                MoveDir.y = jumpSpeed;
        }
        
        MoveDir.y -= gravity * Time.deltaTime;




        // ĳ���� ������.
        controller.Move(MoveDir * Time.deltaTime);
        controller.Move(MoveDir * speed * Time.deltaTime);
        animator.SetFloat("Speed", controller.velocity.magnitude);

        // Dot �±׸���������, Dot �±װ��������ӿ�����Ʈ��ã��
        if (GameObject.FindGameObjectsWithTag("Dot").Length == 0)
        {
            SceneManager.LoadScene("Clear");
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dot") {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            //SceneManager.LoadScene("Fail");
            //isGameOver = true;
            //gameOverText.enabled = true;
        }
    }
}
