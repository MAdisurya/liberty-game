using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CharacterMovement : CharacterAbility {
	public float speed = 2f;

	public override void Ability()
	{
		if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.ATTACKING) { return; }

		if (_character.m_CharacterType == CharacterType.PLAYER)
		{			
			Move(_verticalInput, _horizontalInput, speed);
		}
	}

	// Method that handles the moving of the character
	void Move(float v, float h, float speed)
	{
		Vector3 _v = Vector3.zero;

		if (v > 0)
		{
			_v = transform.forward * v;
		}

		if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.IDLE)
		{
			if (v > 0)
			{
				_charStateMachine.SetState(EMJCharacterStates.CharacterStates.MOVING);
			}
		}
		else if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.MOVING)
		{
			if (v == 0)
			{
				_charStateMachine.SetState(EMJCharacterStates.CharacterStates.IDLE);
			}
		}

		_rigidBody.velocity = _v * speed;
	}
}
