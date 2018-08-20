using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CharacterMovement : MonoBehaviour {

	// public CharMoveStateManager charMoveStateManager;
	private float verticalInputVal;
	private float horizontalInputVal;

	protected Rigidbody m_RigidBody;

	public float speed = 2f;

	void Start()
	{
		m_RigidBody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		// Get Input for vertical and horizontal presses
		verticalInputVal = Input.GetAxis("Vertical");
		horizontalInputVal = Input.GetAxis("Horizontal");

		Move(verticalInputVal, horizontalInputVal, speed);
	}

	// Method that handles the moving of the character
	void Move(float v, float h, float speed)
	{
		float moveX = v * speed;
		float moveZ = h * speed * -1;

		m_RigidBody.velocity = new Vector3(moveX, 0, moveZ);

		if (moveX == 0 && moveZ == 0) { m_RigidBody.velocity = Vector3.zero; }
	}
}
