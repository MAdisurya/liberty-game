using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterStates {
	public enum CharInputStates { CHAR_DASH, CHAR_ATTACK, NO_INPUT }

	public class CharInputStateManager : EMJStateManager {
		
		private static CharInputStates _charInputState = CharInputStates.NO_INPUT;

		private bool dashInput;
		private bool attackInput;

		public static CharInputStates CharInputState { get { return _charInputState; } }

		public override void ChangeState()
		{
			// Check for inputs
			dashInput = Input.GetButtonUp("Dash");
			attackInput = Input.GetButtonUp("Attack");

			// Change charInputStates based on inputs
			if (dashInput)
			{
				_charInputState = CharInputStates.CHAR_DASH;
			}
			else if (attackInput)
			{
				_charInputState = CharInputStates.CHAR_ATTACK;
			}
			else
			{
				_charInputState = CharInputStates.NO_INPUT;
			}
		}
	}
}