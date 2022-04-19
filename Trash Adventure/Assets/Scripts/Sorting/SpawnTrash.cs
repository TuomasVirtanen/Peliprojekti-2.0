using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrash : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnArea;

    [SerializeField]
    private GameObject plastic;

    [SerializeField]
    private GameObject lid;

    [SerializeField]
    private GameObject pizzaSlice;

    [SerializeField]
    private GameObject meal;

    [SerializeField]
    private GameObject cardboard;
    
    [SerializeField]
    private GameObject coffeeMugTrash;

    public static int SpawnCount {get; set;}

    void Start()
    {
        SpawnItem(plastic, CollectableTrash.CollectedPlastics);
        SpawnItem(lid, CollectableTrash.CollectedLids);
        SpawnItem(pizzaSlice, CollectableTrash.CollectedPizzaSlices);
        SpawnItem(meal, CollectableTrash.CollectedMeals);
        SpawnItem(cardboard, CollectableTrash.CollectedCardboards);
        SpawnItem(coffeeMugTrash, CollectableTrash.CollectedCoffeeMugTrashes);
    }

    private void SpawnItem(GameObject trash, int trashAmount)
    {
        MeshCollider c = spawnArea.GetComponent<MeshCollider>();
        float areaX, areaY;
        Vector2 pos;
        for(int i = 0; i < trashAmount; i++)
        {
            areaX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            areaY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(areaX, areaY);
            Instantiate(trash, pos, trash.transform.rotation);
            SpawnCount++;
        }
    }
}
