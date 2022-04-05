using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrash : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnArea;

    [SerializeField]
    private GameObject plastic;
    private int plasticAmount;

    [SerializeField]
    private GameObject lid;

    [SerializeField]
    private GameObject metal;
    private int metalAmount;

    [SerializeField]
    private GameObject bio;
    private int bioAmount;

    [SerializeField]
    private GameObject cardboard;
    private int cardboardAmount;
    [SerializeField]
    private GameObject coffeeMugTrash;

    void Start()
    {
        SpawnItem(lid, CollectableTrash.CollectedLids);
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
        }
    }
}
