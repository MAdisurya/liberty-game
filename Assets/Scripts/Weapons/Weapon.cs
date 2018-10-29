using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	protected GameObject _weaponParent;

	/// <summary>
	/// The damage of the weapon
	/// </summary>
	[Tooltip("The weapon damage.")]
	public int m_Damage;

	public GameObject WeaponParent {
		get { return _weaponParent; }
		set { _weaponParent = value; }
	}

	protected virtual void Start()
	{

	}

	void Update()
	{

	}

	public virtual void EnableWeapon()
	{

	}

	public virtual void DisableWeapon()
	{

	}

	public virtual void UseWeapon()
	{

	}
}
