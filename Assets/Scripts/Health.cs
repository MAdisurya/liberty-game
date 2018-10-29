using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	/// <summary>
	/// Amount of health of an object
	/// </summary>
	[Tooltip("The amount of health this object has.")]
	public int m_Health = 5;

	public void SubtractHealth(int amount)
	{
		m_Health -= amount;
	}

	public void AddHealth(int amount)
	{
		m_Health += amount;
	}
}
