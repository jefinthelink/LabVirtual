using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;

    private float xRotation = 0f;
    void Start()
    {
      
    }

   
    void Update()
    {
     if(Input.GetKey(KeyCode.Mouse1))
     {
            //trocar o imput do botão direito do mouse para outro
         Cursor.lockState = CursorLockMode.Locked; 
         Debug.Log("teste");
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    else
    {

      Cursor.lockState = CursorLockMode.None;
           
    }

    }




}
