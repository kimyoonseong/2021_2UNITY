using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3 : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float interval;
    // Start is called before the first frame update
    IEnumerator Start()
    { // yield을 사용하기 위해 IEnumerator type으로 return
        while (true)
        {
            float rnd = Random.Range(2.0f, 5.0f); // 0.0~5.0 사이의 난수를 만들어낸다. 
            float Rnd = Random.Range(15.0f, 18.0f);
            this.transform.position = new Vector3(20.0f, 18.0f, 29.0f);
            Instantiate(obstaclePrefab, transform.position, transform.rotation);
            // 컬렉션 데이터를 하나씩 return 후 다음 실행 위치 기억 (Unity의 coroutine 참조)
            yield return new WaitForSeconds(interval);
        }
    }
}
