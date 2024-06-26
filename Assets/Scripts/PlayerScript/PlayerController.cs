using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [Header("Movimiento")]
    private Rigidbody2D rb;
    private float inputX;
    private float inputY;
    [SerializeField] private float speedMove;
    [SerializeField] private Camera virtualCamera;
    [Header("Limites")]
    [SerializeField] private float minX; 
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {

    }
    private void FixedUpdate()
    {
        Movement();
        CheckLimits();
    }

    private void Movement()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        Vector2 movePlayer = new Vector2(inputX, inputY).normalized;
        rb.MovePosition(rb.position + movePlayer * speedMove * Time.deltaTime); 

        Vector2 MouseDirection = virtualCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 LookDirection = MouseDirection - rb.position;
        float angle = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    private void CheckLimits()
    {
        Vector2 playerPosition = transform.position;

        playerPosition.x = Mathf.Clamp(playerPosition.x,minX,maxX);
        playerPosition.y = Mathf.Clamp(playerPosition.y,minY,maxY);

        transform.position = playerPosition;
    }

}
