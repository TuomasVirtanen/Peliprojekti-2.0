using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardSorting : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Oikein kierrätetyn efekti")]
    private ParticleSystem oikea;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Cardboard" || other.tag == "CoffeeMugTrash")
        {
            Debug.Log("Correct");

            Instantiate(oikea, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Wrong bin");
            Destroy(other.gameObject);
        }
    }
}
