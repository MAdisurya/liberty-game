using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDash : CharacterAbility {

	private CharacterStates.CharInputStates charInputState;
	private float m_DashDuration;

	/// <summary>
	/// The amount of force the dash has.
	/// </summary>
	public float dashForce = 10f;

	/// <summary>
	/// The duration of the cooldown.
	/// </summary>
	public float dashCoolDown = 1f;

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
