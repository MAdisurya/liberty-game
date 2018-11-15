using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMJCharacterStates
{
	public enum CharacterStates
	{
		IDLE,
		MOVING,
		ATTACKING,
		DASHING,
		DEAD
	}

	public class CharacterStateMachine : MonoBehaviour {

		private CharacterStates _currentCharacterState = CharacterStates.IDLE;
		private CharInputStates charInputState;
		public CharacterStates GetCharacterState { get { return _currentCharacterState; } }
		
		public void SetState(CharacterStates _State)
		{
			_currentCharacterState = _State;
		}
	}
}