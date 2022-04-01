using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalSorting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Metal")
        {
            Debug.Log("Correct");
            Destroy(other.gameObject);
        }
        else if(other.tag != "Metal")
        {
            Debug.Log("Wrong bin");
            Destroy(other.gameObject);
        }
    }
}
