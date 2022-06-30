using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour
{
    public float speed;
    private bool is_collided = false;
    // Start is called before the first frame update
    void Start()
    {
        is_collided = false;
    }

    void OnTriggerStay(Collider other)
    {
        this.is_collided = true;
    }
    void OnTriggerExit(Collider other)
    {
        this.is_collided = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (is_collided)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        else if (is_collided == false)
        {
            transform.Translate(0, 0, 0);
        }
    }
}
