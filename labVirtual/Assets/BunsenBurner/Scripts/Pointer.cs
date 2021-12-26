using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
   public GameObject[] burners;

    // Checks to see if the mouse is hovered over an object that can be turned and if so activates the hover bool. If not, then deactivates all hover bools
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.transform.tag == "Burner")
            {
                hit.transform.gameObject.GetComponent<BurnerTurner>().hovered = true;
            }
        }
        else
        {
            for(int i = 0; i < 3; i++)
            {
                burners[i].GetComponent<BurnerTurner>().hovered = false;
            }
        }

    }
}
