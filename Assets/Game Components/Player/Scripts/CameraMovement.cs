using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float mouseX;
    float rotation =0;
    public int sensitivity = 0;

    public int mouseSensetivity = 100;
    public Transform body;

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;

        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                rotation -= sensitivity * Time.deltaTime;
                rotation = Mathf.Clamp(rotation, -30, 30);
            }
            if (Input.GetKey(KeyCode.E))
            {
                rotation += sensitivity * Time.deltaTime;
                rotation = Mathf.Clamp(rotation, -30, 30);
            }
            if (Input.GetKey(KeyCode.Tab))
            {
                rotation -= 2*sensitivity * Time.deltaTime;
                rotation = Mathf.Clamp(rotation, -90, 90);
            }
        }
        else
        {
            rotation = Mathf.Sign(rotation) * Mathf.Clamp(Mathf.Abs(rotation) - sensitivity * Time.deltaTime , 0 , 90);
        }



        transform.localEulerAngles = new Vector3 (rotation, 0, 0);

        body.Rotate(Vector3.up * mouseX);
    }
}
