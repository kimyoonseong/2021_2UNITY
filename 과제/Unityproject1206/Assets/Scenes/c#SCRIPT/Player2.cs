using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player2 : MonoBehaviour
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
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;
    public GameObject key5;
    public GameObject portal;
    public bool iskey1;
    public bool iskey2;
    public bool iskey3;
    public bool iskey4;
    public bool iskey5;
    public bool isportal;
    public int keycount;
    // Start is called before the first frame update
    void Start()
    {
        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        this.Audio = this.gameObject.AddComponent<AudioSource>();
        this.Audio.clip = this.jumpSound;
        this.Audio.loop = false;

       
        // Ű
        key1.SetActive(true);
        key2.SetActive(false);
        key3.SetActive(false);
        key4.SetActive(false);
        key5.SetActive(false);
        portal.SetActive(false);
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
                
            // ���͸� ���� ��ǥ�� ���ؿ��� ���� ��ǥ�� �������� ��ȯ�Ѵ�.
            //MoveDir = transform.TransformDirection(MoveDir);

            // ���ǵ� ����.
            //MoveDir *= speed;

            // ĳ���� ����
            /*
            if (Input.GetButton("Jump"))
            {
                MoveDir.y = jumpSpeed;
                this.Audio.Play();
            }*/
        else
            direction.y -= gravity * Time.deltaTime;


        controller.Move(direction * speed * Time.deltaTime);
        animator.SetFloat("Speed", controller.velocity.magnitude);





        
       
        
        
        
        if (iskey5 == true)
        {
            portal.SetActive(true);
            key5.SetActive(false);
            key4.SetActive(false);
            key3.SetActive(false);
            key2.SetActive(false);
            key1.SetActive(false);
        }
        else if (iskey4 == true)
        {
            key5.SetActive(true);
            key4.SetActive(false);
            key3.SetActive(false);
            key2.SetActive(false);
            key1.SetActive(false);
            portal.SetActive(false);
        }
        else if (iskey3 == true)
        {
            key4.SetActive(true);
            key3.SetActive(false);
            key2.SetActive(false);
            key1.SetActive(false);
            key5.SetActive(false);
        }
        else if (iskey2 == true)
        {
            key4.SetActive(false);
            key3.SetActive(true);
            key2.SetActive(false);
            key1.SetActive(false);

        }
        else if (iskey1 == true)
        {
            key3.SetActive(false);
            key2.SetActive(true);
            key1.SetActive(false);
        }
        else if (iskey1 == false)
        {
            key2.SetActive(false);
            key1.SetActive(true);
        }







    }


    
     //ĳ���Ϳ� �߷� ����.
    //MoveDir.y -= gravity * Time.deltaTime;

    // ĳ���� ������.
    // controller.Move(MoveDir * Time.deltaTime);
    // Move()�� �̿��� �̵�, �浹 ó��, �ӵ� �� ��� ����
    //controller.Move(MoveDir * speed * Time.deltaTime);
    // Speed �Ķ���͸� ���� ���� �ӵ��� ũ��(Character Controller)�� ����
    //animator.SetFloat("Speed", controller.velocity.magnitude);
    


    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            
            if (isportal == true)
            {
                iskey5 = true;
                isportal = false;
            }
            else if (iskey5 == true)
            {
                iskey5 = false;
                iskey4 = true;
            }
            else if (iskey4 == true)
            {
                iskey4 = false;
                iskey3 = true;
            }
            else if (iskey3 == true)
            {
                iskey3 = false;
                iskey2 = true;
            }
            else if (iskey2 == true)
            {
                iskey2 = false;
                iskey1 = true;
            }
            else if (iskey1 == true)
            {
                iskey1 = false;

            }
            if (keycount > 0)
            {
                keycount--;
            }
            
        }
        
        else if (collision.gameObject.tag == "KEY")
        {
            if (collision.gameObject.name == "key1")
            {
               
                iskey1 = true;
            }
            else if (collision.gameObject.name == "key2")
            {

                iskey1 = false;
                iskey2 = true;
            }
            else if (collision.gameObject.name == "key3")
            {
                iskey2 = false;
                iskey3 = true;
            }
            else if(collision.gameObject.name == "key4")
            {
                iskey3 = false;
                iskey4 = true;
            }
            else if(collision.gameObject.name == "key5")
            {
                iskey4 = false;
                iskey5 = true;
            }
            else if(collision.gameObject.name == "portal")
            {
                iskey5 = false;
                isportal = true;
                SceneManager.LoadScene("Main2");
            }
            keycount++;
        }
    }
}
