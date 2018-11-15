using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAimInput : CharacterAbility {

	public CharacterAim m_CharacterAim;
	public override void Ability()
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
		Quaternion rotationTarget = Quaternion.Euler(0, -(angle - 50), 0);

		// Only rotate the character if not attacking
		if (_charStateMachine.GetCharacterState != EMJCharacterStates.CharacterStates.ATTACKING)
		{
			m_CharacterAim.Rotate(rotationTarget);
		}
	}
}
