using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUpCube : MonoBehaviour
{
    public float speed;
    private bool is_collided = false;
    // �ٸ� GameObject�� �浹�ϴ� ���� ��� ȣ��
    void OnCollisionStay(Collision other)
    {
        this.is_collided = true;
    }
    void OnCollisionExit(Collision other)
    {
        this.is_collided = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        is_collided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_collided)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            
        }
        else if (is_collided == false)
        {
            transform.Translate(0, 0, 0);
        }
    }
}
