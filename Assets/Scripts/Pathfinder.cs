using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> wayPoints;

    CircleCollider2D objCollider;
    int wayPointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        objCollider = GetComponent<CircleCollider2D>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        wayPoints = waveConfig.GetWaypoints();
        transform.position = wayPoints[wayPointIndex].position;
    }


    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(wayPointIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            DestroyIfOutOfBounds(gameObject);
        }
    }

    private void DestroyIfOutOfBounds(GameObject Object)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if(!GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))
        {
            Destroy(Object);
        }
    }
}
