using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchPrefabCreator : MonoBehaviour
{
    public GameObject Prefab;
    public Transform[] SpawnPoints;

    [ContextMenu("Create")]
    public void CreatePrefabs()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            Instantiate(Prefab, SpawnPoints[i].position, SpawnPoints[i].rotation);
        }
    }
}
