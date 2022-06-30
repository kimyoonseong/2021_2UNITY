using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner6 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstaclePrefab;
    public float interval;
    // Start is called before the first frame update
    IEnumerator Start()
    { // yield�� ����ϱ� ���� IEnumerator type���� return
        while (true)
        {
            
            this.transform.position = new Vector3(40.0f, 3.0f, 24.0f);
            Instantiate(obstaclePrefab, transform.position, transform.rotation);
            // �÷��� �����͸� �ϳ��� return �� ���� ���� ��ġ ��� (Unity�� coroutine ����)
            yield return new WaitForSeconds(interval);
        }
    }
}
