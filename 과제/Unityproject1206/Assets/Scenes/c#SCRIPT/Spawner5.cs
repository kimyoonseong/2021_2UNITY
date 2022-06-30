using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner5 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstaclePrefab;
    public float interval;
    // Start is called before the first frame update
    IEnumerator Start()
    { // yield�� ����ϱ� ���� IEnumerator type���� return
        while (true)
        {
            float rnd = Random.Range(2.0f, 5.0f); // 0.0~5.0 ������ ������ ������. 
            float Rnd = Random.Range(15.0f, 18.0f);
            this.transform.position = new Vector3(26.0f, 3.0f, 40.0f);
            Instantiate(obstaclePrefab, transform.position, transform.rotation);
            // �÷��� �����͸� �ϳ��� return �� ���� ���� ��ġ ��� (Unity�� coroutine ����)
            yield return new WaitForSeconds(interval);
        }
    }
}
