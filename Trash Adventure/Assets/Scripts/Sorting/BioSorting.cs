using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioSorting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bio")
        {
            Debug.Log("Correct");
            Destroy(other.gameObject);
        }
        else if(other.tag != "Bio")
        {
            Debug.Log("Wrong bin");
            Destroy(other.gameObject);
        }
    }
}
