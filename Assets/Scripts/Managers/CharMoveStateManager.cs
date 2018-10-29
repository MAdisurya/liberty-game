using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterStates {
	public enum CharMoveStates { 	CHAR_LEFT, CHAR_RIGHT, CHAR_UP, CHAR_DOWN,
									CHAR_UP_LEFT, CHAR_UP_RIGHT, CHAR_DOWN_LEFT, CHAR_DOWN_RIGHT,
									CHAR_IDLE }

	public class CharMoveStateManager : MonoBehaviour {

		protected CharMoveStates currentCharMoveState = CharMoveStates.CHAR_IDLE;

		private float _verticalInput;
		private float _horizontalInput;

		void Update()
		{
			// Get the input for vertical and horizontal presses
			_verticalInput = Input.GetAxis("Vertical");
			_horizontalInput = Input.GetAxis("Horizontal");
		}

		// void CheckMovementDirection()
		// {

		// }
	}
}