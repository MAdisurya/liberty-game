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
	void Attack()
	{
		if (characterWeapon == null) { return; }
		if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.DASHING) { return; }
		if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.ATTACKING) { return; }
		if (_charStateMachine.GetCharacterState == EMJCharacterStates.CharacterStates.DEAD) { return; }

		charInputState = EMJCharacterStates.CharInputStateManager.CharInputState;

		if (charInputState == EMJCharacterStates.CharInputStates.CHAR_ATTACK)
		{
			characterWeapon.UseWeapon();
			StartCoroutine(EnableThenDisableState(EMJCharacterStates.CharacterStates.ATTACKING, characterWeapon.m_AttackInterval));
		}
	}

	public override void Ability()
	{
		base.Ability();

		Attack();
	}
}
