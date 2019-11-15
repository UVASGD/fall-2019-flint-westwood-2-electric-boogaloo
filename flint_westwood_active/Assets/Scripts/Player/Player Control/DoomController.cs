using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoomController : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Transform crosshair;
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;
    private bool isFiring;


    private int boxHealth;
    // Start is called before the first frame update
    void Start()
    {
        isFiring = false;
        mainCamera = Camera.main; 
        boxHealth = 3;
        Cursor.visible = false;
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        minX = GetWorldViewportBounds(Vector3.zero).x;
        maxX = GetWorldViewportBounds(Vector3.right).x;
        minY = GetWorldViewportBounds(Vector3.zero).y;
        maxY = GetWorldViewportBounds(Vector3.up).y;
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var xMousePos = Mathf.Clamp(mousePos.x, minX, maxX);
        var yMousePos = Mathf.Clamp(mousePos.y, minY, maxY);
        
        crosshair.transform.position = new Vector3(xMousePos, yMousePos, crosshair.transform.position.z);
        Vector3 move = new Vector3(xMousePos, transform.position.y, transform.position.z);
        transform.position = move;
        Debug.Log(crosshair.transform.position);
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isFiring", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Doom_Pistol_Shoot"))
            {
                HandleBreakable();
            }
        } else if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isFiring", false);
        }
        
    }

    Vector3 GetWorldViewportBounds(Vector3 viewportPoint)
    {
        return mainCamera.ViewportToWorldPoint(viewportPoint);
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
