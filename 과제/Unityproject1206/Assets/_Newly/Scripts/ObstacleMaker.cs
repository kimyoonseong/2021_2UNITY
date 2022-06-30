using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMaker : MonoBehaviour
{
    public GameObject obstacle;
    
    void Start()
    {
        InvokeRepeating("Maker", 2f, 2f);
    }

    void Update()
    {
        
    }

    public void Maker()
    {
        float[] tempPos = new float[3];
        for (int i = 0; i < 3; i++)
        {
            tempPos[i] = Random.Range(-1f, 1f);
        }
        Vector3 rndPos = transform.position + new Vector3(tempPos[0], tempPos[1], tempPos[2]);
        
        GameObject clone = Instantiate(obstacle, rndPos, Quaternion.identity);
        //Destroy(clone, 3f);
    }
}
