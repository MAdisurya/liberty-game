using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	protected GameObject _weaponParent;

	protected float _damage;

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
