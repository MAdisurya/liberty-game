using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterStates {
	public enum CharInputStates { CHAR_DASH, CHAR_ATTACK, NO_INPUT }

	public class CharInputStateManager : EMJStateManager {
		
		private static CharInputStates _charInputState = CharInputStates.NO_INPUT;

		private bool dashInput;

		public static CharInputStates CharInputStates { get { return _charInputState; } }

		public override void ChangeState()
		{
			// Check for inputs
			dashInput = Input.GetButtonUp("Dash");

			// Change charInputStates based on inputs
			_charInputState = (dashInput) ? CharInputStates.CHAR_DASH : CharInputStates.NO_INPUT;
		}
	}
}