using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	protected GameObject _weaponParent;
	protected GameObject m_WeaponObject;
	protected Rigidbody _rigidBody;
	protected EMJCharacterStates.CharacterStateMachine m_CharacterStateMachine;

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
		m_CharacterStateMachine = GetComponent<EMJCharacterStates.CharacterStateMachine>();

		m_WeaponObject = new GameObject();

		// Add Rigidbody component to the new weapon object.
		_rigidBody = (Rigidbody) m_WeaponObject.AddComponent<Rigidbody>();
		// Set rigid body to kinematic to avoid collisions with other weapons
		_rigidBody.isKinematic = true;
	}

	protected virtual void Update()
	{
		if (m_CharacterStateMachine == null) { return; }

		EMJCharacterStates.CharacterStates currentCharState = m_CharacterStateMachine.CurrentCharacterState;

		if (currentCharState != EMJCharacterStates.CharacterStates.DEAD)
		{
			m_WeaponObject.transform.rotation = _weaponParent.transform.rotation;
		}
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
