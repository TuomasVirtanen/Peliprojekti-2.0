using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticSorting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Plastic")
        {
            Debug.Log("Correct");
            Destroy(other.gameObject);
        }
        else if(other.tag != "Plastic")
        {
            Debug.Log("Wrong bin");
            Destroy(other.gameObject);
        }
    }
}
