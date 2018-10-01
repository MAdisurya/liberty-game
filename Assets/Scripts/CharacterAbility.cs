using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]

public class CharacterAbility : MonoBehaviour {

	protected Character _character;
	protected Rigidbody _rigidBody;
	protected float _verticalInput;
	protected float _horizontalInput;
	public bool abilityAllowed = true;

	public Rigidbody CharRigidBody { get { return _rigidBody; } }

	protected virtual void Start()
	{
		_character = GetComponent<Character>();
		_rigidBody = GetComponent<Rigidbody>();
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
}
