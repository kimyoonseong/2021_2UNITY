using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public void bigsize()
    {
        // x, y 방향에 대해 크기를 2배로 한다.
        float depth = this.transform.localScale.x;
        this.transform.localScale = new Vector3(depth, 2.0f, 2.0f);
        this.transform.Translate(Vector3.forward * 3.0f * Time.deltaTime);
    }
    
}
