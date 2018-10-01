using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : CharacterAbility {

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

		characterWeapon.UseWeapon();
	}

	public override void Ability()
	{
		Attack();
	}
}
