using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private GameObject FirePosition;
    private Vector3 initialPosition;
    [SerializeField] private float speed = 1.0f; 
    public bool moveToFire = false;
    public bool moveToInitialPosition = false;

    private void Start()
    {
        SetValues();
    }
    private void SetValues()
    {
        FirePosition = GameObject.FindGameObjectWithTag("Fire");
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

    public void MoveToFire() 
    {
        if (!moveToInitialPosition)
        {
            Debug.Log("movendo");
            moveToFire = true;
        }
    }

    public void MoveToInitialPosition()
    {

        if (!moveToFire)
        {
            moveToInitialPosition = true;
        }
    }

}
