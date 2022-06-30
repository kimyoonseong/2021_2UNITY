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
            // 컬렉션 데이터를 하나씩 return 후 다음 실행 위치 기억 (Unity의 coroutine 참조)
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
