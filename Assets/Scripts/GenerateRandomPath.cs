using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomPath : MonoBehaviour
{
    [SerializeField] int numberOfNodes = 4;
    [SerializeField] float minXBound = -8f;
    [SerializeField] float maxXBound = 8f;
    [SerializeField] float minYBound = -5f;
    [SerializeField] float maxYBound = 10f;
    int heheheHawLeftOrRight;

    [SerializeField] float paddingTop;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingLeft;

    Vector2 minBounds;
    Vector2 maxBounds;

    void Awake()
    {
        heheheHawLeftOrRight = Random.Range(0, 2);
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        GeneratePath();
    }

    void GeneratePath()
    {
        for (int i = 0; i < numberOfNodes; i++)
        {
            addNewNode(gameObject, i);
        }
    }

    void addNewNode(GameObject parentOb, int i)
    {
        GameObject childOb = new GameObject("Waypoint"+i);
        childOb.transform.SetParent(parentOb.transform);
        Vector2 wayPointPosition = new Vector2();

        if (i == 0)
        {   
            if (heheheHawLeftOrRight == 0)
            {
                wayPointPosition.x = -Camera.main.orthographicSize;
            }
            else
            {
                wayPointPosition.x = Camera.main.orthographicSize;
            }
            wayPointPosition.y = Random.Range(minYBound, maxYBound);
            childOb.transform.position = wayPointPosition;
        }
        else if(i == numberOfNodes - 1)
        {
            //Debug.Log("Reached last loop: " + i);
            if (heheheHawLeftOrRight == 0)
            {
                wayPointPosition.x = Camera.main.orthographicSize;
            }
            else
            {
                wayPointPosition.x = -Camera.main.orthographicSize;
            }
            wayPointPosition.y = Random.Range(minYBound, maxYBound);
            childOb.transform.position = wayPointPosition;
        }
        else
        {
            wayPointPosition.x = Mathf.Clamp(transform.position.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
            wayPointPosition.y = Mathf.Clamp(transform.position.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
            childOb.transform.position = wayPointPosition;
        }
    }

    
}
