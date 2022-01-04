using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Color color = Color.red;
    [SerializeField] private float distance = 50f;
    [SerializeField] private float initialWidth = 0.02f;
    [SerializeField] private float finalWidth = 0.01f;
    private GameObject lightCollider;
    private Vector3 lightPosition;
    private Vector3 finalPosition;
    private LineRenderer lineRenderer;
    public Material material;



    private void Start()
    {
        SetValues();
    }

    private void SetValues()
    {
        lightCollider = new GameObject();
        lightCollider.AddComponent<Light>();
        lightCollider.GetComponent<Light>().intensity = 8;
        lightCollider.GetComponent<Light>().bounceIntensity = 8;
        lightCollider.GetComponent<Light>().range = finalWidth * 2;
        lightCollider.GetComponent<Light>().color = color;

         lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = material;
        lineRenderer.SetColors(color,color);
        lineRenderer.SetWidth(initialWidth,finalWidth);
        lineRenderer.SetVertexCount(2);
         finalPosition = transform.position + transform.right * distance;    
    }

    

    public void showRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, Mathf.Infinity))
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, finalPosition);
            
        }

    }

    public void TurnOnRay()
    {
        lineRenderer.enabled = true;
    }

    public void TurnOfRay()
    {
        lineRenderer.enabled = false;
    }




}
