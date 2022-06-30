using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour
{
    public float speed;

    private bool is_collided = false;
    // 다른 GameObject와 충돌하는 동안 계속 호출
    void OnCollisionStay(Collision other)
    {
        this.is_collided = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (is_collided)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }
}
