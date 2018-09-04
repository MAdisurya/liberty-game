using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDash : CharacterAbility {

	private CharacterStates.CharInputStates charInputState;
	private float m_DashDuration;

	/// <summary>
	/// The amount of force the dash has.
	/// </summary>
	[Tooltip("The amount of force applied to the dash")]
	public float dashForce = 10f;

	/// <summary>
	/// The duration of the cooldown.
	/// </summary>
	[Tooltip("The cool down duration after a dash has happened")]
	public float dashCoolDown = 1f;

	/// <summary>
	/// The duration of the dash
	/// </summary>
	[Tooltip("The duration of how long the dash force will be applied to the character")]
	public float dashDuration = 1f;

	protected override void Start()
	{
		base.Start();

		m_DashDuration = dashDuration;
		dashDuration = 0;
	}

	public override void Ability()
	{	
		base.Ability();
		charInputState = CharacterStates.CharInputStateManager.CharInputStates;

		if (charInputState == CharacterStates.CharInputStates.CHAR_DASH)
		{ 
			dashDuration = m_DashDuration;
		}

		Dash(_verticalInput, _horizontalInput, dashForce);
	}

	void Dash(float v, float z, float force)
	{	
		if (dashDuration > 0)
		{
			v *= force;
			z *= force * -1;

			_rigidBody.AddForce(v, 0, z, ForceMode.Impulse);

			dashDuration -= Time.deltaTime;
		}
	}
}
