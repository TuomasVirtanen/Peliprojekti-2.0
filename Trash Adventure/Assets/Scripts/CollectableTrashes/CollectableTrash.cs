using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTrash : MonoBehaviour
{
    public static int CollectedPlastics {get; set;}
    public static int CollectedLids {get; set;}
    public static int CollectedPizzaSlices {get; set;}
    public static int CollectedMeals {get; set;}
    public static int CollectedBios {get; set;}
    public static int CollectedCardboards {get; set;}
    public static int CollectedCoffeeMugTrashes {get; set;}
    public static int CollectedMetals {get; set;}
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            // Lisätään aina siihen laskuriin, joka vastaa kerättyä roskaa
            
            if(this.CompareTag("Plastic"))
            {
                CollectedPlastics++;
            }

            if(this.CompareTag("Lid"))
            {
                CollectedLids++;
            }

            if(this.CompareTag("PizzaSlice"))
            {
                CollectedPizzaSlices++;
            }

            if(this.CompareTag("Meal"))
            {
                CollectedMeals++;
            }

            if(this.CompareTag("Bio"))
            {
                CollectedBios++;
            }

            if(this.CompareTag("Cardboard"))
            {
                CollectedCardboards++;
            }

            if(this.CompareTag("CoffeeMugTrash"))
            {
                CollectedCoffeeMugTrashes++;
            }

            if(this.CompareTag("Metal"))
            {
                CollectedMetals++;
            }

            Destroy(gameObject);
        }
    }
}
