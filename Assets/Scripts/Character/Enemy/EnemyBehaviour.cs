using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]

public class EnemyBehaviour : MonoBehaviour {

	/// <summary>
	/// The enemies state machine.
	/// </summary>
	protected EMJCharacterStates.CharacterStateMachine _charStateMachine;

	void Start()
	{
		_charStateMachine = GetComponent<EMJCharacterStates.CharacterStateMachine>();
	}

	void Update()
	{
		Behave();
	}

	protected virtual void Behave()
	{

	}
}
