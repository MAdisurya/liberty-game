using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	protected GameObject _weaponParent;
	protected GameObject m_WeaponObject;
	protected Rigidbody _rigidBody;

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
		m_WeaponObject = new GameObject();

		// Add Rigidbody component to the new weapon object.
		_rigidBody = (Rigidbody) m_WeaponObject.AddComponent<Rigidbody>();
		// Set rigid body to kinematic to avoid collisions with other weapons
		_rigidBody.isKinematic = true;
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
