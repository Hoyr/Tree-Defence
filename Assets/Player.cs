using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed =5f;
    public Rigidbody2D rb;
    public Camera cam;

    public Transform firePoint;
    public GameObject shotPrefab;
    public float shotForce = 20f;
    
    Controls controls;
    Vector2 movementInput;
    Vector2 lookPosition;
    
    void Awake()
    {
        controls = new Controls();
        controls.Player.Shoot.performed += ctx => Shoot();
        controls.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Player.FireDirection.performed += ctx => lookPosition = cam.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookAt = lookPosition - rb.position;
        rb.rotation =Mathf.Atan2(lookAt.y,lookAt.x) * Mathf.Rad2Deg - 90f;
    }

    void Shoot()
    {
        GameObject shot = Instantiate(shotPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * shotForce, ForceMode2D.Impulse);
        Destroy(shot, 10f);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}