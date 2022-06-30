using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float interval;
    // Start is called before the first frame update
    IEnumerator Start()
    { // yield�� ����ϱ� ���� IEnumerator type���� return
        //Destroy(obstaclePrefab, 5.0f);
        while (true)
        {
            //float rnd = Random.Range(0.0f, 20.0f); // 0.0~5.0 ������ ������ ������. 
            float Rnd = Random.Range(12f, 13.0f);
            this.transform.position = new Vector3(Rnd, 20.0f, 17.0f);
            Instantiate(obstaclePrefab, transform.position, transform.rotation);
            // �÷��� �����͸� �ϳ��� return �� ���� ���� ��ġ ��� (Unity�� coroutine ����)
            yield return new WaitForSeconds(interval);
        }
    }
}
