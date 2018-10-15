using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAimInput : MonoBehaviour {

	public CharacterAim m_CharacterAim;

	void Update()
	{
		if (m_CharacterAim == null) { return; }

		// Get Mouse position
		Vector3 mousePos = Input.mousePosition;
		Vector3 lookPos = Camera.main.ScreenToViewportPoint(mousePos);

		// Get this object position on screen
		Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

		// Get angle between two points
		float angle = m_CharacterAim.AngleBetweenTwoPoints(positionOnScreen, lookPos);

		// Set rotation
		Quaternion rotationTarget = Quaternion.Euler(0, -(angle + 45), 0);

		m_CharacterAim.Rotate(rotationTarget);
	}
}
