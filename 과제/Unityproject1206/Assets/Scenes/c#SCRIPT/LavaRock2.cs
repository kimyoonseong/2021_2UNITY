using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRock2 : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.8f);
        transform.Rotate(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.01f);

        }
    }
}
