using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float forwardSpeed = 3.0f;
    public float sideSpeed = 3.0f;

    public Transform movementTransform;

    private Vector3 deltaForward;
    private Vector3 deltaRight;

    void Start()
    {
        if (movementTransform == null)
        {
            movementTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        deltaForward = movementTransform.forward * forwardSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        deltaRight = movementTransform.right * sideSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;

        transform.Translate(deltaForward);
        transform.Translate(deltaRight);
    }
}
