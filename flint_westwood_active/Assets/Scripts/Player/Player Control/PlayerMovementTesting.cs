using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTesting : MonoBehaviour
{
    [SerializeField] private float moveSpeedModifier = 1f;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Vector2 moveDirection;

    [SerializeField] private Rigidbody2D playerRigidbody2D;
    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void ProcessInputs()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontal, vertical, 0f);
        moveSpeed = Mathf.Clamp(moveDirection.magnitude, 0.0f, 1.0f);
        moveDirection.Normalize();
    }

    void MovePlayer()
    {
        Vector2 playerVelocity =
            playerRigidbody2D.position + (moveDirection * moveSpeed * moveSpeedModifier) * Time.deltaTime;
        playerRigidbody2D.MovePosition(playerVelocity);
    }
}
