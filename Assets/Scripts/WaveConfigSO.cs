using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [Header("Gameobjects and transforms")]
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] GameObject randomizedPath;

    [Header("Game balance parameters")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBeetweenSpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    [Header("Instance manager")]
    [SerializeField] float timeBeforeDestroy = 10f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public Transform GetStartingWaypoint()
    {
        if (pathPrefab != null)
        {
            return pathPrefab.GetChild(0);
        }
        else
        {
            GameObject instance = Instantiate(randomizedPath, new Vector2(0, 0), Quaternion.identity);
            pathPrefab = instance.transform;
            Destroy(instance, timeBeforeDestroy);
            return pathPrefab.GetChild(0);
        }
    }


    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBeetweenSpawns - spawnTimeVariance,
                                        timeBeetweenSpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
