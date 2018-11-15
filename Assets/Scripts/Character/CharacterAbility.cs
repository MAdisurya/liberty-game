using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbility : MonoBehaviour {

	protected Character _character;
	protected Rigidbody _rigidBody;
	protected EMJCharacterStates.CharacterStateMachine _charStateMachine;
	protected float _verticalInput;
	protected float _horizontalInput;
	public bool abilityAllowed = true;

	public Rigidbody CharRigidBody { get { return _rigidBody; } }

	protected virtual void Start()
	{
		_character = GetComponent<Character>();
		_rigidBody = GetComponent<Rigidbody>();
		_charStateMachine = GetComponent<EMJCharacterStates.CharacterStateMachine>();
	}

	void Update()
	{	
		_verticalInput = Input.GetAxis("Vertical");
		_horizontalInput = Input.GetAxis("Horizontal");

		if (abilityAllowed) { Ability(); }
	}

	public virtual void Ability()
	{
		
	}

	protected IEnumerator EnableThenDisableState(EMJCharacterStates.CharacterStates _State, float _Duration = 0.5f)
	{
		_charStateMachine.SetState(_State);

		yield return new WaitForSeconds(_Duration);

		_charStateMachine.SetState(EMJCharacterStates.CharacterStates.IDLE);
	}
}
