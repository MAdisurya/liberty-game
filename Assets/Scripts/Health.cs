using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	/// <summary>
	/// Amount of health of an object
	/// </summary>
	[Tooltip("The amount of health this object has.")]
	public int m_Health = 5;

	/// <summary>
	/// The maximum amount of health this object can have
	/// </summary>
	[Tooltip("The maximum amount of health this object can have.")]
	public int m_MaxHealth = 5;

	public void SubtractHealth(int amount)
	{
		if (m_Health > 0)
		{
			m_Health -= amount;
		}
	}

	public void AddHealth(int amount)
	{
		if (m_Health < m_MaxHealth)
		{
			m_Health += amount;
		}
	}
}
