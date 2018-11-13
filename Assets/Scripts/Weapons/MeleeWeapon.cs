using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon {

	private BoxCollider m_BoxCollider;
	private Weapon m_Weapon;

	[Header("Melee Attack Region")]

	/// <summary>
	/// The X size of the attack region of the melee weapon.
	/// </summary>
	[Tooltip("The X size of the attack region of the melee weapon")]
	public float m_RegionSizeX = 1f;

	/// <summary>
	/// The Y size of the attack region of the melee weapon.
	/// </summary>
	[Tooltip("The Y size of the attack region of the melee weapon")]
	public float m_RegionSizeY = 1f;

	/// <summary>
	/// The Z size of the attack region of the melee weapon.
	/// </summary>
	[Tooltip("The Z size of the attack region of the melee weapon")]
	public float m_RegionSizeZ = 1f;

	[Header("Attack")]

	/// <summary>
	/// The duration the melee attack will last
	/// </summary>
	[Tooltip("The duration of the melee attack")]
	public float m_AttackDuration = 1f;

	protected override void Start()
	{
		base.Start();

		CreateMeleeRegion();
		DisableWeapon();
	}

	private void CreateMeleeRegion()
	{
		m_BoxCollider = (BoxCollider) m_WeaponObject.AddComponent<BoxCollider>();
		m_Weapon = (Weapon) m_WeaponObject.AddComponent<Weapon>();

		m_WeaponObject.name = "Character Weapon";
		m_WeaponObject.tag = "Weapon";

		m_BoxCollider.size = new Vector3(m_RegionSizeX, m_RegionSizeY, m_RegionSizeZ);
		m_BoxCollider.center = new Vector3 (1, _weaponParent.transform.position.y, 0);

		m_BoxCollider.isTrigger = true;

		m_WeaponObject.transform.SetParent(_weaponParent.transform);
		m_WeaponObject.transform.position = new Vector3(_weaponParent.transform.position.x, 0, 0);

		m_Weapon.m_Damage = m_Damage;
	}

	public override void EnableWeapon()
	{
		base.EnableWeapon();
		m_BoxCollider.enabled = true;
	}

	public override void DisableWeapon()
	{
		base.DisableWeapon();
		m_BoxCollider.enabled = false;
	}

	public override void UseWeapon()
	{
		base.UseWeapon();

		if (attackInterval <= 0)
		{
			StartCoroutine(EnableThenDisableWeapon());

			attackInterval = m_AttackInterval;
		}

	}

	private IEnumerator EnableThenDisableWeapon()
	{
		EnableWeapon();

		yield return new WaitForSeconds(m_AttackDuration);

		DisableWeapon();
	}
}
