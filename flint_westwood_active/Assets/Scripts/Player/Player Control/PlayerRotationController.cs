using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerRotationController : MonoBehaviour
{
    public Sprite[] aimSprites;
    private Dictionary<float, Sprite> aimDirectionDictionary;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] GameObject crosshair;

    void Start()
    {
        Cursor.visible = false;
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        aimDirectionDictionary = new Dictionary<float, Sprite>();
    }

    void Update()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crosshair.transform.position = new Vector2(mouseWorld.x, mouseWorld.y);
        
        Vector3 pointDirection = (transform.position - mouseWorld).normalized;
        float aimAngle = Mathf.Atan2(pointDirection.y, pointDirection.x) * Mathf.Rad2Deg;
        Vector3 mouse = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);

//        Debug.Log("Aim Angle: " + aimAngle);
        HandleAimAnimations(aimAngle);
    }

    private void HandleAimAnimations(float aimAngle)
    {
        if (aimAngle >= 90f && aimAngle <= 180f)
        {
            HandleAimQuadrant(4, aimAngle);
        }
        else if (aimAngle <= -90f && aimAngle >= -180f)
        {
            HandleAimQuadrant(1, aimAngle);
        } 
        else if (aimAngle <= -0.01f && aimAngle >= -90f)
        {
            HandleAimQuadrant(2, aimAngle);
        } 
        else if (aimAngle >= 0.01f && aimAngle <= 90f)
        {
            HandleAimQuadrant(3, aimAngle);
        }
    }

    private void HandleAimQuadrant(int quadrant, float aimAngle)
    {
        if (quadrant < 1 || quadrant > 4) return;
        switch (quadrant)
        {
            case 1:
                if (aimAngle <= -90f && aimAngle >= -120f)
                {
                    SetAimParameters(true, 0f, 1f);
                }
                else if (aimAngle <= -120f && aimAngle >= -150f)
                {
                    SetAimParameters(true, 0.25f, 0.9f);
                } else if (aimAngle <= -150f && aimAngle >= -180f)
                {
                    SetAimParameters(true, 0.65f, 0.7f);
                }
                break;
            case 2:
                if (aimAngle <= -0.001f && aimAngle >= -30f)
                {
                    SetAimParameters(true, -1f, 0f);
                } else if (aimAngle <= -30f && aimAngle >= -60f)
                {
                    SetAimParameters(true, -0.65f, 0.7f);
                } else if (aimAngle <= -60f && aimAngle >= -90f)
                {
                    SetAimParameters(true, -0.25f, 0.9f);
                }
                break;
            case 3:
                if (aimAngle >= -179f && aimAngle <= 0f)
                {
                    SetAimParameters(true, 1f, 0f);
                } else if (aimAngle >= 30f && aimAngle <= 60f)
                {
                    SetAimParameters(true, -0.65f, -0.7f);
                } else if (aimAngle >= 60f && aimAngle <= 90f)
                {
                    SetAimParameters(true, -0.25f, -0.9f);
                }
                break;
            case 4:
                if (aimAngle >= 90f && aimAngle <= 120f)
                { 
                    SetAimParameters(true, 0f, -1f);
                }
                else if (aimAngle >= 120f && aimAngle <= 150f)
                {
                    SetAimParameters(true, 0.25f, -0.9f);
                }
                else if (aimAngle >= 150f && aimAngle <= 180f)
                {
                    SetAimParameters(true, 0.65f, -0.7f);
                }
                break;
            default:
                break;
        }
    } 

    private void SetAimParameters(bool isAiming, float horizontalVal, float verticalVal)
    {
        playerAnimator.SetBool("Aiming", isAiming);
        playerAnimator.SetFloat("AimHorizontal", horizontalVal);
        playerAnimator.SetFloat("AimVertical", verticalVal);
    }
}
