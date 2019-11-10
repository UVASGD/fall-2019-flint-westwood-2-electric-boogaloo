using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoomController : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Transform crosshair;

    private int boxHealth;
    // Start is called before the first frame update
    void Start()
    {
        boxHealth = 3;
        Cursor.visible = false;
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crosshair.transform.position = new Vector3(screenPos.x, screenPos.y, crosshair.transform.position.z);
        Vector3 move = new Vector3(screenPos.x, transform.position.y, transform.position.z);
        transform.position = move;
        Debug.Log(screenPos);

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isFiring", true);
            HandleBreakable();
        } else if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isFiring", false);
        }
        
    }

    void HandleBreakable()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Breakable"))
            {
                if (boxHealth <= 0)
                {
                    hit.collider.gameObject.GetComponent<Animator>().SetBool("isDestroyed", true); 
                }
                else
                {
                    hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Hit");
                    boxHealth--;  
                }

                Debug.Log("Hit breakable object!");
            }
        }
    }
}
