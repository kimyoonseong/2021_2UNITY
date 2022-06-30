using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float interval;
    //public float range = 1.0f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            // �÷��� �����͸� �ϳ��� return �� ���� ���� ��ġ ��� (Unity�� coroutine ����)
            yield return new WaitForSeconds(interval);
            transform.position = new Vector3(Random.Range(35, 45), transform.position.y
                , transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
