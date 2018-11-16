using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Character))]

public class EnemyBehaviour : MonoBehaviour {

	/// <summary>
	/// The enemies state machine.
	/// </summary>
	protected EMJCharacterStates.CharacterStateMachine _charStateMachine;

	/// <summary>
	/// The player transform
	/// </sumary>
	[Tooltip("The player transform")]
	public Transform m_Player;

	void Awake()
	{
		// If player doesn't exist, assert
		Assert.IsNotNull(m_Player);
	}

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
