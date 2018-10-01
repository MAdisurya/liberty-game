using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon {

	private BoxCollider _boxCollider;
	private GameObject _attackRegion;

	/// <summary>
	/// The X size of the attack region of the melee weapon.
	/// </summary>
	[Tooltip("The X size of the attack region of the melee weapon")]
	public float _regionSizeX = 1f;

	/// <summary>
	/// The Y size of the attack region of the melee weapon.
	/// </summary>
	[Tooltip("The Y size of the attack region of the melee weapon")]
	public float _regionSizeY = 1f;

	/// <summary>
	/// The Z size of the attack region of the melee weapon.
	/// </summary>
	[Tooltip("The Z size of the attack region of the melee weapon")]
	public float _regionSizeZ = 1f;

	protected override void Start()
	{
		base.Start();

		CreateMeleeRegion();
	}

	private void CreateMeleeRegion()
	{
		_attackRegion = new GameObject();
		_boxCollider = (BoxCollider) _attackRegion.AddComponent(typeof(BoxCollider));

		_attackRegion.name = "Character Weapon";

		_boxCollider.size = new Vector3(_regionSizeX, _regionSizeY, _regionSizeZ);
		_boxCollider.center = new Vector3 (1, _weaponParent.transform.position.y, 0);

		_boxCollider.isTrigger = true;

		_attackRegion.transform.SetParent(_weaponParent.transform);
	}

	public override void UseWeapon()
	{

	}
}
