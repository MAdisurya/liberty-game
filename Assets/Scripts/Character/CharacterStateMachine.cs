using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMJCharacterStates
{
	public enum CharacterStates
	{
		IDLE,
		ATTACKING,
		DASHING,
		DEAD
	}

	public class CharacterStateMachine : MonoBehaviour {

		private CharacterStates _currentCharacterState = CharacterStates.IDLE;

		public CharacterStates CurrentCharacterState { get { return _currentCharacterState; } }

		public void SetState(CharacterStates state)
		{
			_currentCharacterState = state;
		}
	}
}