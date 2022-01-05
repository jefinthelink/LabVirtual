using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    #region Variaveis
    [Header("controlador")]
    [SerializeField] private CharacterController controller;
    [Header("velocidade")]
    [SerializeField] private float speed = 12f;
    #endregion
    #region Metodos
    void Update()
    {
        Move();
    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
    #endregion
}
