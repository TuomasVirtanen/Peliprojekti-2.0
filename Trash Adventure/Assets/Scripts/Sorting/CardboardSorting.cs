using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardSorting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Cardboard")
        {
            Debug.Log("Correct");
            Destroy(other.gameObject);
        }
        else if(other.tag != "Cardboard")
        {
            Debug.Log("Wrong bin");
            Destroy(other.gameObject);
        }
    }
}
