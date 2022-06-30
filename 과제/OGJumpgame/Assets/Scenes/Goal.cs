using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Goal : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    // 충돌했는가(true), 충돌하지 않았는가(false)를 나타낸다.
    private bool is_collided = false;
    // 다른 GameObject와 충돌하는 동안 계속 호출
    void OnCollisionStay(Collision other)
    {
        this.is_collided = true;
    }
    private GUIStyle guiStyle = new GUIStyle();
    void OnGUI()
    {
        if (is_collided)
        { // 충돌했으면
          // 화면에 '성공'이라고 표시
           
            guiStyle.fontSize = 40;
            GUI.Label(new Rect(Screen.width / 2, 80, 100, 40), "성공",guiStyle);
            guiStyle.normal.textColor = Color.white;
            if (Input.GetMouseButtonDown(0))
            { // 좌클릭되었으면
                SceneManager.LoadScene("Title"); // Main scene 이동
            }
        }
    }
}
