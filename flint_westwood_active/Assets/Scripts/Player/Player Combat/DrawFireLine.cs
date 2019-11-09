using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawFireLine : MonoBehaviour
{

    [SerializeField] private GameObject dash;
    [SerializeField] private int bounces;
    [SerializeField] private float spaceBetweenDashes;
    [SerializeField] private float lineMaxDistance;
    [SerializeField] private float bounceOffset;
    [SerializeField] private float movementPerSecond;
    [SerializeField] private LayerMask lineHitLayer;
    [SerializeField] private Transform firePoint;

    private List<GameObject> dashPool;
    private float moveTimer;
    public RaycastHit2D rayHit;

    private void Start()
    {
        dashPool = new List<GameObject>();
    }

    public void DrawLine(Vector3 mousePosition)
    {

        int dashIndex = 0;

        moveTimer += Time.deltaTime;

        if (movementPerSecond * moveTimer > spaceBetweenDashes)
        {
            moveTimer = 0;
        }

        Vector3 rayStartPoint = firePoint.position;

        Vector3 rayDirection = mousePosition - firePoint.position;

        for (int i = 0; i <= bounces; i++)
        {

            Ray2D dashRay = new Ray2D(rayStartPoint, rayDirection);

            rayHit = Physics2D.Raycast(rayStartPoint, rayDirection, lineMaxDistance, lineHitLayer);

            if (rayHit)
            {

                float distanceToEnd = Vector3.Distance(rayStartPoint, rayHit.point);

                for (float j = 0; j < distanceToEnd; j += spaceBetweenDashes)
                {

                    if (dashPool.Count <= dashIndex)
                    {
                        dashPool.Add(Instantiate(dash));
                    }

                    dashPool[dashIndex].transform.position = dashRay.GetPoint(j + (movementPerSecond * moveTimer));

                    dashPool[dashIndex].transform.right = (dashPool[dashIndex].transform.position - new Vector3(rayHit.point.x, rayHit.point.y, 0)).normalized;

                    dashPool[dashIndex].SetActive(true);

                    dashIndex++;
                }
                
                Debug.DrawLine(rayStartPoint, rayHit.point);

                Vector3 newDirection = Vector3.Reflect(rayDirection, rayHit.normal);

                rayDirection = newDirection;

                rayStartPoint = rayHit.point + (rayHit.normal * bounceOffset);

            }
            else
            {

                Vector3 noHitPoint = dashRay.GetPoint(lineMaxDistance);

                float distanceToEnd = Vector3.Distance(rayStartPoint, noHitPoint);

                for (float j = 0; j < distanceToEnd; j += spaceBetweenDashes)
                {

                    if (dashPool.Count <= dashIndex)
                    {

                        dashPool.Add(Instantiate(dash));

                    }

                    dashPool[dashIndex].transform.position = dashRay.GetPoint(j + (movementPerSecond * moveTimer));

                    dashPool[dashIndex].transform.right = (dashPool[dashIndex].transform.position - new Vector3(noHitPoint.x, noHitPoint.y, 0)).normalized;

                    dashPool[dashIndex].SetActive(true);

                    dashIndex++;

                }

                Debug.DrawLine(rayStartPoint, noHitPoint);

                break;

            }

        }

        for (int k = dashIndex; k < dashPool.Count; k++)
        {

            dashPool[k].SetActive(false);

        }

    }

    public void ClearLine()
    {

        for (int i = 0; i < dashPool.Count; i++)
        {

            dashPool[i].SetActive(false);

        }

    }
    
}