using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMJCharacterStates
{
	public class CharacterAnimState : MonoBehaviour {

		public EMJCharacterStates.CharacterStateMachine _charStateMachine;
		public Animator _animator;

		void Update()
		{
			switch (_charStateMachine.GetCharacterState)
			{
				case EMJCharacterStates.CharacterStates.MOVING:
					_animator.Play("Move");
					break;
				case EMJCharacterStates.CharacterStates.ATTACKING:
					_animator.Play("Attack");
					break;
				default:
					_animator.Play("Idle");
					break;
			}
		}		
	}
}
