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
    private GameObject bio;

    [SerializeField]
    private GameObject cardboard;
    
    [SerializeField]
    private GameObject coffeeMugTrash;

    [SerializeField]
    private GameObject metal;

    public static int SpawnCount {get; set;}
    public static bool NothingToSpawn {get; set;}

    void Start()
    {
        NothingToSpawn = false;
        SpawnItem(plastic, CollectableTrash.CollectedPlastics);
        SpawnItem(lid, CollectableTrash.CollectedLids);
        SpawnItem(pizzaSlice, CollectableTrash.CollectedPizzaSlices);
        SpawnItem(meal, CollectableTrash.CollectedMeals);
        SpawnItem(bio, CollectableTrash.CollectedBios);
        SpawnItem(cardboard, CollectableTrash.CollectedCardboards);
        SpawnItem(coffeeMugTrash, CollectableTrash.CollectedCoffeeMugTrashes);
        SpawnItem(metal, CollectableTrash.CollectedMetals);
        Debug.Log("SpawnCount:" + SpawnCount);
        if(SpawnCount == 0)
        {
            NothingToSpawn = true;
            Debug.Log("Ei mitään spawnattavaa");
        }
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
