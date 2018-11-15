using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAim : CharacterAbility {

	/// <summary>
	/// The smoothness of the rotation
	/// </summary>
	[Tooltip("The smoothness of the rotation animation")]
	public float m_Smooth = 3f;

	/// <summary>
	/// The target
	/// </summary>
	[Tooltip("The target.")]
	public GameObject m_Target;

	public void RotateToTarget(Vector3 targetPos)
	{
		// Get the screen position of this object
		Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

		// Get angle between the two points
		float angle = AngleBetweenTwoPoints(positionOnScreen, targetPos);

		// Set rotation target
		Quaternion rotationTarget = Quaternion.Euler(0, -(angle - 45), 0);

		// Dampen Character towards rotation target
		transform.rotation = Quaternion.Slerp(transform.rotation,
			rotationTarget, Time.deltaTime * m_Smooth);
	}

	public void Rotate(Quaternion target)
	{
		// Dampen character towards rotation target
		transform.rotation = Quaternion.Slerp(transform.rotation, 
			target, Time.deltaTime * m_Smooth);
	}

	public float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
		// return angle between two points
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

	public override void Ability()
	{
		if (m_Target == null) { return; }

		RotateToTarget(Camera.main.WorldToViewportPoint(m_Target.transform.position));
	}
}
