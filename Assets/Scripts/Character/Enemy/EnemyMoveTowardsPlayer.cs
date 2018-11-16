using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTowardsPlayer : EnemyBehaviour {

	/// <summary>
	/// The enemies character movement component
	/// </summary>
	[Tooltip("The enemies character movement component")]
	public CharacterMovement m_CharacterMovement;

	/// <summary>
	/// The minimum distance the enemy must stay away from the player
	/// </summary>
	[Tooltip("The minimum distance the enemy must stay away from the player")]
	public float m_AllowedDistance = 2f;

	protected override void Behave()
	{
		if (m_Player == null) { return; }
		if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.ATTACKING) { return; }

		// Get the distance between the player and this enemy
		float distance = Vector3.Distance(m_Player.position, transform.position);
		// The step size is equal to speed times frame time.
		float step = m_CharacterMovement.speed * Time.deltaTime;

		if (distance > m_AllowedDistance)
		{
			transform.position = Vector3.MoveTowards(transform.position, m_Player.position, step);
			_charStateMachine.SetState(EMJCharacterStates.CharacterStates.MOVING);
		}
	}
}
