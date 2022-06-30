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
    // �浹�ߴ°�(true), �浹���� �ʾҴ°�(false)�� ��Ÿ����.
    private bool is_collided = false;
    // �ٸ� GameObject�� �浹�ϴ� ���� ��� ȣ��
    void OnCollisionStay(Collision other)
    {
        this.is_collided = true;
    }
    private GUIStyle guiStyle = new GUIStyle();
    void OnGUI()
    {
        if (is_collided)
        { // �浹������
          // ȭ�鿡 '����'�̶�� ǥ��
           
            guiStyle.fontSize = 40;
            GUI.Label(new Rect(Screen.width / 2, 80, 100, 40), "����",guiStyle);
            guiStyle.normal.textColor = Color.white;
            if (Input.GetMouseButtonDown(0))
            { // ��Ŭ���Ǿ�����
                SceneManager.LoadScene("Title"); // Main scene �̵�
            }
        }
    }
}
