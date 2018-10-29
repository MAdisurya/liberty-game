using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CharacterMovement : CharacterAbility {

	public float speed = 2f;

	public override void Ability()
	{
		if (_character.m_CharacterType == CharacterType.PLAYER)
		{
			Move(_verticalInput, _horizontalInput, speed);
		}
	}

	// Method that handles the moving of the character
	void Move(float v, float z, float speed)
	{
		v *= speed;
		z *= speed * -1;

		_rigidBody.velocity = new Vector3(v, 0, z);
	}
}
