using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	private GameObject m_HealthBar;
	
	/// <summary>
	/// Amount of health of an object
	/// </summary>
	[Tooltip("The amount of health this object has.")]
	public float m_Health = 5;

	/// <summary>
	/// The maximum amount of health this object can have
	/// </summary>
	[Tooltip("The maximum amount of health this object can have.")]
	public float m_MaxHealth = 5;

	public GameObject HealthBar { get { return m_HealthBar; } }

	void Start()
	{
		m_HealthBar = new GameObject("HealthBar");
		SpriteRenderer _spriteRenderer = (SpriteRenderer) m_HealthBar.AddComponent<SpriteRenderer>();

		_spriteRenderer.sprite = (Sprite) Resources.Load("Sprites/HealthBar", typeof(Sprite));
		_spriteRenderer.color = Color.red;

		m_HealthBar.transform.localScale = new Vector3(1, 0.15f, 1);
		m_HealthBar.transform.rotation = Quaternion.Euler(0, 135, 0);
	}

	void Update()
	{
		m_HealthBar.transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.x, transform.position.z);
	}

	public void SubtractHealth(int amount)
	{
		if (m_Health > 0)
		{
			m_Health -= amount;
			m_HealthBar.transform.localScale = new Vector3(m_HealthBar.transform.localScale.x - (amount / m_MaxHealth), 0.15f, 1);
		}
	}

	public void AddHealth(int amount)
	{
		if (m_Health < m_MaxHealth)
		{
			m_Health += amount;
		}
	}
}
