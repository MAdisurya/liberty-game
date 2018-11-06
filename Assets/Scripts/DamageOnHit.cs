using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DamageOnHit : MonoBehaviour {

	private Character m_Character;

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

	void Start()
	{
		m_Character = GetComponent<Character>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (characterHealth == null) { return; }
		if (!m_DamageAllowed) { return; }

		// Check if the colliding object is a weapon
		if (other.gameObject.tag == "Weapon")
		{
			// Get the weapons parent
			Transform weaponParent = other.transform.parent;
			// Get the weapon
			Weapon weapon = other.GetComponent<Weapon>();

			if (weapon == null) { return; }

			// Check if the colliding object is not this object type
			if (weaponParent.gameObject.tag != gameObject.tag)
			{
				characterHealth.SubtractHealth(weapon.m_Damage);
				Debug.Log(gameObject.tag + ": " + characterHealth.m_Health);

				if (characterHealth.m_Health <= 0)
				{
					m_Character.Die();
				}
			}
		}
	}
}
