using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;

    private Camera mainCamera;
    private DrawFireLine fireLine;
    [SerializeField] Transform crosshair;

    private void Start()
    {

        mainCamera = Camera.main;

        fireLine = GetComponent<DrawFireLine>();

    }

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {

            fireLine.DrawLine(crosshair.position);

        }

        if (Input.GetMouseButtonUp(0))
        {

            GameObject newBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);

            Vector3 mousePos = crosshair.position;

            newBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(mousePos.y - firePoint.position.y, mousePos.x - firePoint.position.x) * Mathf.Rad2Deg - 90));

            fireLine.ClearLine();

        }

    }

}