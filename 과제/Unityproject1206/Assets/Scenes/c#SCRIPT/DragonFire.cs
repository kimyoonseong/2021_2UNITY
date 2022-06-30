using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFire : MonoBehaviour
{
    [SerializeField] private float speed;
    //[SerializeField] private float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    //private void OnTriggerEnter(Collider collision)
    //{
    //    //Debug.Log(other.transform.name + "에게 대미지" + damage + "를 입혔습니다");
    //    Destroy(this.gameObject);
    //}
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

        }
    }
}
