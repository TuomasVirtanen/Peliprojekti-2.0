using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTrash : MonoBehaviour
{
    public int CollectedLids {get; set;}
    public int CollectedCoffeeMugTrashes {get; set;}
    // jne...
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            // Lisätään aina siihen laskuriin, joka vastaa kerättyä roskaa
            
            if(this.CompareTag("Lid"))
            {
                CollectedLids++;
            }

            if(this.CompareTag("CoffeeMugTrash"))
            {
                CollectedCoffeeMugTrashes++;
            }
            // jne...

            Destroy(gameObject);
        }
    }
}
