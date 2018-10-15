using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CharacterMovement : CharacterAbility {

	protected Rigidbody m_RigidBody;

	public float speed = 2f;

	void Start()
	{
		m_RigidBody = GetComponent<Rigidbody>();
	}

	public override void Ability()
	{
		Move(_verticalInput, _horizontalInput, speed);
	}

	// Method that handles the moving of the character
	void Move(float v, float z, float speed)
	{
		v *= speed;
		z *= speed * -1;

		m_RigidBody.velocity = new Vector3(v, 0, z);
	}
}
