using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : CharacterAbility {

	private CharacterStates.CharInputStates charInputState;

	public Weapon characterWeapon;

	void Awake()
	{
		if (characterWeapon == null) { return; }

		characterWeapon.WeaponParent = this.gameObject;
	}

	/// <summary>
	/// Called when character is attacking
	/// </summary>
	void Attack()
	{
		if (characterWeapon == null) { return; }

		charInputState = CharacterStates.CharInputStateManager.CharInputState;

		if (charInputState == CharacterStates.CharInputStates.CHAR_ATTACK) 
		{
			characterWeapon.UseWeapon();
		}
	}

	public override void Ability()
	{
		base.Ability();

		Attack();
	}
}
