using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform cameraRig;
    [SerializeField] float dist;

    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;

    [SerializeField] float yMinLimit;
    [SerializeField] float yMaxLimit;

    private float x;
    private float y;
    private Vector2 lookInput, screenCenter, mouseDistance;
    // Start is called before the first frame update
    void Start()
    {
        x = target.rotation.x;
        //y = target.rotation.y;

        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;
        if (target)
        {
            lookInput.x = Input.mousePosition.x;
            lookInput.y = Input.mousePosition.y;


            mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;

            mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

            mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

            if (dist >= 4f)
            {
                dist = 4f;
            }
            
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
           // y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            if (mouseDistance.x > 0.3 || mouseDistance.x < -0.3)
                x += mouseDistance.x * xSpeed * 0.02f;
           // else if ((mouseDistance.y > 0.4 || mouseDistance.y < -0.4))
           //     y -= mouseDistance.y * ySpeed * 0.02f;

           // y = ClampAngle(y, yMinLimit, yMaxLimit);
            
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0f, 0f, -dist) + target.position + new Vector3(0f, 0f, 0f);
            position.y += 1.5f;

            transform.rotation = rotation;
            transform.position = position;

        }
        /*
        RaycastHit hit;
        Vector3 rayDir = (transform.position - cameraRig.position).normalized;
        LayerMask layerMask = (1 << LayerMask.NameToLayer("Player")) + (1 << LayerMask.NameToLayer("Obstacle"));
        if (Physics.Raycast(cameraRig.position, rayDir, out hit, 15f, ~layerMask))
        {
            dist = Vector3.Distance(cameraRig.position, hit.point) - 3f;
            if (dist < 2)
                dist = 2f;
        }
        else
            dist = 4f;
        */
    }
        
    float ClampAngle(float anlge, float min, float max)
    {
        if (anlge < -360f)
            anlge += 360f;
        if (anlge > 360f)
            anlge -= 360f;

        return Mathf.Clamp(anlge, min, max);
    }

}