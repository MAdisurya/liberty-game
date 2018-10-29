using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon {

	private BoxCollider m_BoxCollider;
	private GameObject m_AttackRegion;
	private Weapon m_Weapon;
	private float attackInterval;

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

	/// <summary>
	/// The interval of which attacks are allowed
	/// </summary>
	[Tooltip("The interval of which attacks are allowed")]
	public float m_AttackInterval = 0.5f;

	protected override void Start()
	{
		base.Start();

		CreateMeleeRegion();
		DisableWeapon();
	}

	void Update()
	{
		if (attackInterval > 0)
		{
			attackInterval -= Time.deltaTime;
		}

		m_AttackRegion.transform.rotation = _weaponParent.transform.rotation;
	}

	private void CreateMeleeRegion()
	{
		m_AttackRegion = new GameObject();
		m_BoxCollider = (BoxCollider) m_AttackRegion.AddComponent(typeof(BoxCollider));
		m_Weapon = (Weapon) m_AttackRegion.AddComponent(typeof(Weapon));

		m_AttackRegion.name = "Character Weapon";
		m_AttackRegion.tag = "Weapon";

		m_BoxCollider.size = new Vector3(m_RegionSizeX, m_RegionSizeY, m_RegionSizeZ);
		m_BoxCollider.center = new Vector3 (1, _weaponParent.transform.position.y, 0);

		m_BoxCollider.isTrigger = true;

		m_Weapon.m_Damage = m_Damage;

		m_AttackRegion.transform.SetParent(_weaponParent.transform);
	}

	public override void EnableWeapon()
	{
		m_BoxCollider.enabled = true;
	}

	public override void DisableWeapon()
	{
		m_BoxCollider.enabled = false;
	}

	public override void UseWeapon()
	{
		if (attackInterval <= 0)
		{
			StartCoroutine(EnableThenDisableWeapon());

			attackInterval = m_AttackDuration + m_AttackInterval;
		}
	}

	private IEnumerator EnableThenDisableWeapon()
	{
		EnableWeapon();

		yield return new WaitForSeconds(m_AttackDuration);

		DisableWeapon();
	}
}
