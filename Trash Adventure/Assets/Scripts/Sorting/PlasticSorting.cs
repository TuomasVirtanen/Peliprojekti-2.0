using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticSorting : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Oikein kierr�tetyn efekti")]
    private ParticleSystem oikea;
    [SerializeField]
    [Tooltip("V��rim kierr�tetyn efekti")]
    private ParticleSystem wrong;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Plastic" || other.tag == "Lid")
        {
            Debug.Log("Correct");
            Instantiate(oikea, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Wrong bin");
            Instantiate(wrong, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
