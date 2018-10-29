using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DamageOnHit : MonoBehaviour {

	/// <summary>
	/// The health object of this character
	/// </summary>
	[Tooltip("The health object of this character.")]
	public Health characterHealth;
	
	/// <summary>
	/// Toggle to allow damage or not
	/// </summary>
	[Tooltip("Toggle to allow damage or not.")]
	public bool m_DamageAllowed = true;

	void Awake()
	{
		Assert.IsNotNull(characterHealth);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (characterHealth == null) { return; }

		// Check if the colliding object is a weapon
		if (other.gameObject.tag == "Weapon")
		{
			// Get the weapons parent
			Transform weaponParent = other.transform.parent;
			// Get the weapon
			Weapon weapon = other.GetComponent<Weapon>();

			if (weapon == null) { return; }

			// Check if the colliding object is a player weapon
			if (weaponParent.gameObject.tag != gameObject.tag)
			{
				characterHealth.SubtractHealth(weapon.m_Damage);
				Debug.Log(characterHealth.m_Health);
			}
		}
	}
}
