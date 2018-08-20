using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDash : CharacterAbility {

	private bool dashInputVal;
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

	void Start()
	{
		m_DashDuration = dashDuration;
		dashDuration = 0;

		_rigidBody = GetComponent<Rigidbody>();
	}

	public override void Ability()
	{	
		dashInputVal = Input.GetButtonUp("Dash");

		if (dashInputVal) 
		{ 
			dashDuration = m_DashDuration;
		}

		_verticalInput = Input.GetAxis("Vertical");
		_horizontalInput = Input.GetAxis("Horizontal");

		Dash(_verticalInput, _horizontalInput, dashForce);
	}

	void Dash(float v, float z, float force)
	{	
		if (dashDuration > 0)
		{
			float dashX = v * force;
			float dashZ = z * force * -1;

			_rigidBody.AddForce(dashX, 0, dashZ, ForceMode.Impulse);

			dashDuration -= Time.deltaTime;
		}
	}
}
