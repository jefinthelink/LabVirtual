using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region variaveis
    [Header("Sensibilidade do mouse")]
    [SerializeField] private float mouseSensitivity = 100f;
    [Header("corpo do player")]
    [SerializeField] private Transform playerBody;
    private float xRotation = 0f;
    #endregion
    #region metodos
    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
         Cursor.lockState = CursorLockMode.Confined; 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);    
    }
    #endregion
}
