using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject FirePosition;
    public FireCollider fireCollider;
    private Vector3 initialPosition;
    [SerializeField] private float speed = 1.0f; 
    public bool moveToFire = false;
    public bool moveToInitialPosition = false;
    public bool isFireState = false;

    private void Start()
    {
        SetValues();
    }
    private void SetValues()
    {
        
      
        initialPosition = transform.position;
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
            }
        }

        if (moveToInitialPosition)
        {
            MoveWards(initialPosition);
            if (transform.position == initialPosition)
            {
                moveToInitialPosition = false;
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
            isFireState = true;
        }
    }

    public void HandlerState()
    {
        
        if (!isFireState && !fireCollider.busy)
        {
            MoveToFire();
        }
        if(isFireState)
        {
            MoveToInitialPosition();
        }
    }

    private void MoveToInitialPosition()
    {

        if (!moveToFire)
        {
            moveToInitialPosition = true;
            isFireState = false;
        }
    }


    private void OnMouseDown()
    {
        HandlerState();
    }

}
