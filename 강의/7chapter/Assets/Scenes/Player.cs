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
        // Space bar�� ���� ���¶��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("space");
        }
        //Debug.Log(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.A))
        { // Object�� �Ÿ� ����
            float rnd = Random.Range(0.0f, 5.0f); // 0.0~5.0 ������ ������ ������. 
            this.transform.position = new Vector3(0.0f, 1.5f, rnd); // �ڽ�(Capsule)�� ��ġ�� ����.
        }
        if (Input.GetKeyDown(KeyCode.B))
        { // Object�� ȸ��
            float rnd = Random.Range(0.0f, 360.0f);
            this.transform.rotation = Quaternion.Euler(0.0f, rnd, 0.0f); // y�� ���� ȸ�� ���¸� ���Ƿ� ����.
        }
        if (Input.GetKeyDown(KeyCode.C))
        { // Object�� ȸ��
            float rnd = Random.Range(0.0f, 5.0f);
            this.transform.localScale= new Vector3(rnd, rnd, rnd); // y�� ���� ȸ�� ���¸� ���Ƿ� ����.
        }


        if (Input.GetKey(KeyCode.UpArrow))
        { // ��Ű�� forward(��).
            this.transform.Translate(Vector3.forward * 3.0f * Time.deltaTime);
            // this.transform.Translate(new Vector3(0.0f, 0.0f, 3.0f * Time.deltaTime));
            //�� ������ �����信 ��ũ��Ʈ ���� �Ҷ�.
            //this.transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * force * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        { // ��Ű�� back(��).
            this.transform.Translate(Vector3.back * 3.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        { // ��Ű�� left(��).
            this.transform.Translate(Vector3.left * 3.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        { // ��Ű�� right(��).
            this.transform.Translate(Vector3.right * 3.0f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.R))
        { // RŰ�� ��ȸ��.
            this.transform.Rotate(0.0f, 90.0f * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.L))
        { // LŰ�� ��ȸ��.
            this.transform.Rotate(0.0f, -90.0f * Time.deltaTime, 0.0f);
        }


        if (Input.GetKey(KeyCode.G))
        {
            GameObject go = GameObject.Find("Shield") as GameObject;
            go.GetComponent<Weapon>().bigsize(); // Weapon.cs�� bigsize() method ȣ��
        }
    }

}
