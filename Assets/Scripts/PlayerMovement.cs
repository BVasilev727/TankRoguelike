using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 movementVector;

    [SerializeField]
    float moveSpeed = 3f;
    [SerializeField]
    float rotationSpeed = 10f;

    [SerializeField]
    Vector3 shootArea;

    [SerializeField]
    Projectile projectile;

    private Vector3 currMoveVelocity;
    private Vector3 MoveDampVelocity;
    public float MoveSmoothTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        movementVector = new Vector3();
        
    }

    private void Update()
    {
        movementVector.x = Input.GetAxisRaw("HorizontalUI");
        movementVector.z = Input.GetAxisRaw("VerticalUI");
        movementVector.y = 0;
        movementVector *= moveSpeed;
        
        rb.velocity = movementVector;
       
        if(movementVector != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementVector.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        
        HandleShootInput();
    }

    private void HandleShootInput()
    {
        if(Input.GetButton("Fire1"))
        {
            PlayerGun.Instance.Shoot();
        }
    }

    public void RaiseSpeed()
    {
        if (moveSpeed < 10f)
        {
            moveSpeed++;
        }
        else return;
    }   

}
