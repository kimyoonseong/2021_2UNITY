using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bullet : MonoBehaviour
{
    private bool is_collided = false;
    public float speed;

    void OnCollisionStay(Collision other)
    {
        this.is_collided = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private GUIStyle guiStyle = new GUIStyle();

    void OnGUI()
    {
        
        if (is_collided)
        {
            //transform.position = new Vector3(0, -2, 0);
             //ȭ�鿡 '����'�̶�� ǥ��
            guiStyle.fontSize = 40;
            GUI.Label(new Rect(Screen.width / 2, 80, 100, 40), "����", guiStyle);
            guiStyle.normal.textColor = Color.red;
            Time.timeScale = 0;
            if (Input.GetMouseButtonDown(0))
                { // ��Ŭ���Ǿ�����
                
                SceneManager.LoadScene("Main"); // Main scene �̵�
                }
        }
       
    }
}
