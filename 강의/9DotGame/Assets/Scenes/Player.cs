using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 지정
    public float rotationSpeed = 360f; // 회전 속도 지정
    CharacterController characterController;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp( // 메소드를 조합해 플레이어의 방향 변환
            transform.forward,
            direction,
            rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
            );
            transform.LookAt(transform.position + forward);
        }
        // Move()를 이용해 이동, 충돌 처리, 속도 값 얻기 가능
        characterController.Move(direction * moveSpeed * Time.deltaTime);

        // Speed 파라미터를 통해 현재 속도의 크기(Character Controller)를 전달
        animator.SetFloat("Speed", characterController.velocity.magnitude);

        // Dot 태그를 가져오고, Dot 태그가 붙은 게임 오브젝트를 찾음
        if (GameObject.FindGameObjectsWithTag("Dot").Length == 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dot")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Enemy")
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
