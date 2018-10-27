using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes
	{
		MouseXAndY,
		MouseX,
		MouseY,
	}

	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHorizontal = 3.0f;
	public float sensitivityVertical = 3.0f;

	public float minimumVertical = -45.0f;
	public float maximumVertical = 45.0f;

	public bool lockMouse = true;

	private float rotationX;
	private float rotationY;


	void Start ()
	{
		var body = GetComponent<Rigidbody>();
		if (body)
			body.freezeRotation = true;

		if (lockMouse)
			Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void FixedUpdate () {

	}

	private void Update()
	{
		switch (axes)
		{
			case RotationAxes.MouseX:
				handleXRotation();
				break;

			case RotationAxes.MouseY:
				handleYRotation();
				break;

			case RotationAxes.MouseXAndY:
				handleXRotation();
				handleYRotation();
				break;

			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private void handleYRotation()
	{
		rotationX -= Input.GetAxis("Mouse Y") * sensitivityVertical;
		rotationX = Mathf.Clamp(rotationX, minimumVertical, maximumVertical);

		var currentRotationY = transform.localEulerAngles.y;

		transform.localEulerAngles = new Vector3(rotationX, currentRotationY, 0);
	}

	private void handleXRotation()
	{
		rotationY = Input.GetAxis("Mouse X") * sensitivityHorizontal;
		transform.Rotate(0, rotationY, 0);
	}
}
