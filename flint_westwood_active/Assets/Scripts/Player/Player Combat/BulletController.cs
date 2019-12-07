using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private int numberOfHits;
    [SerializeField] private float bounceDistance;
    [SerializeField] private float damage;

    private Vector3 lastPosition;

    private void Update()
    {

        transform.position += transform.up * moveSpeed * Time.deltaTime;

        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, transform.up, bounceDistance);

        if (rayHit)
        {
          //  print("It's Hit!");
//            Breakable health = rayHit.collider.GetComponent<Breakable>();

            if (false)
            {

                

            }

            //transform.up = Vector3.Reflect(transform.up, rayHit.normal);

            numberOfHits--;
            print("ray hits =" + numberOfHits);
            

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy (gameObject);
    }

}