using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigid : MonoBehaviour
{
    // Start is called before the first frame update
    public float force = 300.0f;
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        { // ↑키로 안쪽 방향.
            this.transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * force * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        { // ↓키로 앞쪽 방향.
            this.transform.GetComponent<Rigidbody>().AddForce(Vector3.back * force * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        { // ←키로 왼쪽 방향.
            this.transform.GetComponent<Rigidbody>().AddForce(Vector3.left * force * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        { //→키로 오른쪽 방향.
            this.transform.GetComponent<Rigidbody>().AddForce(Vector3.right * force * Time.deltaTime);

        }


        if (Input.GetKeyDown(KeyCode.Keypad0))
        { // 텐키(숫자 키패드)의 0.
            Physics.gravity = Vector3.zero; // 중력을 제로로 한다.
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        { // 텐키의 8.
            Physics.gravity = Vector3.up; // 중력을 위 방향으로 한다.
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        { // 텐키의 2.
            Physics.gravity = Vector3.down; // 중력을 아래 방향으로 한다.
        }
    }
}
