using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	protected GameObject _weaponParent;
	protected GameObject m_WeaponObject;
	protected Rigidbody _rigidBody;
	
	protected float attackInterval;

	[Header("General")]
	/// <summary>
	/// The characters state machine
	/// </summary>
	[Tooltip("The characters state machine")]
	public EMJCharacterStates.CharacterStateMachine m_CharacterStateMachine;

	/// <summary>
	/// The damage of the weapon
	/// </summary>
	[Tooltip("The weapon damage.")]
	public int m_Damage;

		/// <summary>
	/// The interval of which attacks are allowed
	/// </summary>
	[Tooltip("The interval of which attacks are allowed")]
	public float m_AttackInterval = 0.5f;

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

	protected virtual void Update()
	{
		if (m_CharacterStateMachine == null) { return; }

		EMJCharacterStates.CharacterStates currentCharState = m_CharacterStateMachine.GetCharacterState;

		if (currentCharState != EMJCharacterStates.CharacterStates.DEAD)
		{
			m_WeaponObject.transform.rotation = _weaponParent.transform.rotation;
		}

		if (attackInterval > 0)
		{
			attackInterval -= Time.deltaTime;
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
