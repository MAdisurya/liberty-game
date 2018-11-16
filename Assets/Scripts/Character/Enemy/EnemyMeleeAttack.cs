using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : EnemyBehaviour {

	/// <summary>
	/// The character attack component
	/// </summary>
	[Tooltip("the character attack component")]
	public CharacterAttack _charAttack;

	/// <summary>
	/// the range of which the enemy will attack
	/// </sumary>
	[Tooltip("the range of which the enemy will attack")]
	public float m_MeleeAttackRange = 2f;

	protected override void Behave()
	{
		if (m_Player == null) { return; }

		// Get the distance between the player and this enemy
		float distBetweenPlayer = Vector3.Distance(m_Player.position, transform.position);

		// If the enemy is within melee range of the player, then attack.
		if (distBetweenPlayer <= m_MeleeAttackRange)
		{
			_charAttack.EnemyAttack();
		}

		// if enemy is attacking and attack interval is 0, set it to idle state
		if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.ATTACKING)
		{
			if (_charAttack.characterWeapon.AttackInterval <= 0)
			{
				_charStateMachine.SetState(EMJCharacterStates.CharacterStates.IDLE);
			}			
		}
	}
}
