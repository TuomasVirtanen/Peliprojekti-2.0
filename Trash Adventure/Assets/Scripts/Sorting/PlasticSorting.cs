using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticSorting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Plastic" || other.tag == "Lid")
        {
            Debug.Log("Correct");
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Wrong bin");
            Destroy(other.gameObject);
        }
    }
}
