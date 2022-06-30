using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Space bar가 눌린 상태라면
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("space");
        }
        //Debug.Log(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.A))
        { // Object의 거리 변함
            float rnd = Random.Range(0.0f, 5.0f); // 0.0~5.0 사이의 난수를 만들어낸다. 
            this.transform.position = new Vector3(0.0f, 1.5f, rnd); // 자신(Capsule)의 위치를 변경.
        }
        if (Input.GetKeyDown(KeyCode.B))
        { // Object의 회전
            float rnd = Random.Range(0.0f, 360.0f);
            this.transform.rotation = Quaternion.Euler(0.0f, rnd, 0.0f); // y축 방향 회전 상태를 임의로 변경.
        }
        if (Input.GetKeyDown(KeyCode.C))
        { // Object의 회전
            float rnd = Random.Range(0.0f, 5.0f);
            this.transform.localScale= new Vector3(rnd, rnd, rnd); // y축 방향 회전 상태를 임의로 변경.
        }


        if (Input.GetKey(KeyCode.UpArrow))
        { // ↑키로 forward(전).
            this.transform.Translate(Vector3.forward * 3.0f * Time.deltaTime);
            // this.transform.Translate(new Vector3(0.0f, 0.0f, 3.0f * Time.deltaTime));
            //그 프리팹 유니토에 스크립트 적용 할때.
            //this.transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * force * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        { // ↓키로 back(후).
            this.transform.Translate(Vector3.back * 3.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        { // ←키로 left(좌).
            this.transform.Translate(Vector3.left * 3.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        { // →키로 right(우).
            this.transform.Translate(Vector3.right * 3.0f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.R))
        { // R키로 우회전.
            this.transform.Rotate(0.0f, 90.0f * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.L))
        { // L키로 좌회전.
            this.transform.Rotate(0.0f, -90.0f * Time.deltaTime, 0.0f);
        }


        if (Input.GetKey(KeyCode.G))
        {
            GameObject go = GameObject.Find("Shield") as GameObject;
            go.GetComponent<Weapon>().bigsize(); // Weapon.cs의 bigsize() method 호출
        }
    }

}
