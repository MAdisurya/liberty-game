using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : CharacterAbility {

	private EMJCharacterStates.CharInputStates charInputState;

	public Weapon characterWeapon;

	void Awake()
	{
		if (characterWeapon == null) { return; }

		characterWeapon.WeaponParent = this.gameObject;
	}

	protected override void Start()
	{
		base.Start();
	}

	/// <summary>
	/// Called when character is attacking
	/// </summary>
	public void PlayerAttack()
	{
		if (characterWeapon == null) { return; }
		if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.DASHING) { return; }
		if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.DEAD) { return; }
		if (_character.m_CharacterType == CharacterType.AI) { return; }

		charInputState = EMJCharacterStates.CharInputStateManager.CharInputState;

		if (charInputState == EMJCharacterStates.CharInputStates.CHAR_ATTACK)
		{
			_charStateMachine.SetState(EMJCharacterStates.CharacterStates.ATTACKING);
		}
		else if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.ATTACKING)
		{
			if (characterWeapon.AttackInterval <= 0)
			{
				_charStateMachine.SetState(EMJCharacterStates.CharacterStates.IDLE);
			}
		}

		if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.ATTACKING)
		{
			characterWeapon.UseWeapon();
		}
	}

	/// <summary>
	/// Called when enemy is attacking
	/// </summary>
	public void EnemyAttack()
	{
		if (characterWeapon == null) { return; }
		if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.DASHING) { return; }
		if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.DEAD) { return; }
		if (_character.m_CharacterType == CharacterType.PLAYER) { return; }

		if (_charStateMachine.GetCharacterState != EMJCharacterStates.CharacterStates.ATTACKING)
		{
			_charStateMachine.SetState(EMJCharacterStates.CharacterStates.ATTACKING);
		}
		else if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.ATTACKING)
		{
			if (characterWeapon.AttackInterval <= 0)
			{
				_charStateMachine.SetState(EMJCharacterStates.CharacterStates.IDLE);
			}
		}

		if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.ATTACKING)
		{
			characterWeapon.UseWeapon();
		}
	}

	public override void Ability()
	{
		base.Ability();

		PlayerAttack();
	}
}
