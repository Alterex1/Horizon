using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUnit : MonoBehaviour
{
    private float stoppingDistance = 0.1f;

    private Vector3 targetPosition;
    private float moveSpeed = 10f;

    private void Awake()
    {
        targetPosition = transform.position;
    }


    private void Update()
    {

        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            float turnSpeed = 10f;
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }

    }

    public void MoveToPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;

    }

    public void RotateToPosition(Vector3 targetPosition, float turnSpeed)
    {
        Vector3 rotationDirection = (targetPosition - transform.position).normalized;

        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, rotationDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
    }


}
