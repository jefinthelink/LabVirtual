using UnityEngine;

public class Cube : MonoBehaviour
{
    #region variaveis
    [Header("posição do fogo")]
    public GameObject FirePosition;
    [Header("colisor do fogo")]
    public FireCollider fireCollider;
    [Header("velocidade de movimento")]
    [SerializeField] private float speed = 1.0f; 
    [HideInInspector] public bool moveToFire = false;
    [HideInInspector] public bool moveToInitialPosition = false;
    [HideInInspector]public bool isFireState = false;
    private Vector3 initialPosition;
    private CubeHeating cubeHeating;

    #endregion

    #region Metodos
    private void Start()
    {
        SetValues();
    }
    private void SetValues()
    {
        initialPosition = transform.position;
        cubeHeating = transform.GetComponent<CubeHeating>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (moveToFire)
        {
            MoveWards(FirePosition.transform.position);
            if (transform.position == FirePosition.transform.position)
            {
                moveToFire = false;
                cubeHeating.seconds = 0f;
               
            }
        }

        if (moveToInitialPosition)
        {
            MoveWards(initialPosition);
            if (transform.position == initialPosition)
            {
                moveToInitialPosition = false;
                cubeHeating.seconds = 0f;
                
            }

        }

    }
    private void MoveWards(Vector3 target)
    {
        transform.position =  Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    private void MoveToFire() 
    {
        if (!moveToInitialPosition)
        {
        
            moveToFire = true;
            cubeHeating.starttemperature = cubeHeating.temperatureCeucius;
            
            

        }
    }
    public void HandlerState()
    {
        
        if (!isFireState && !fireCollider.busy)
        {
            MoveToFire();
        }
        if(transform.position == FirePosition.transform.position)
        {
            MoveToInitialPosition();
        }
    }
    private void MoveToInitialPosition()
    {

        if (!moveToFire)
        {
            moveToInitialPosition = true;
            cubeHeating.starttemperature = cubeHeating.temperatureCeucius;
            
        }
    }
    #endregion
}
