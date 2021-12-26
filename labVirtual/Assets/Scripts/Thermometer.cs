using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometer : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    private Vector3 initialPosition;
    [SerializeField] private Transform ThermometerPosition;
    private bool moveToThermometerPosition = false;
    private bool moveToInitialPosition = false;
    private bool useState = false;

    void Start()
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
        if (moveToThermometerPosition)
        {
            MoveWards(ThermometerPosition.transform.position);
            if (transform.position == ThermometerPosition.transform.position)
            {
                moveToThermometerPosition = false;
                useState = true;
            }
        }

        if (moveToInitialPosition)
        {
            MoveWards(initialPosition);
            if (transform.position == initialPosition)
            {
                moveToInitialPosition = false;
                useState = false;
            }

        }

    }

    private void MoveWards(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void HandlerState()
    {
        
        if (!useState)
        {
            moveToThermometerPosition = true;
        }
        if (useState)
        {
            moveToInitialPosition = true;
        }
    }

    private void OnMouseDown()
    {
        HandlerState();
    }


}
