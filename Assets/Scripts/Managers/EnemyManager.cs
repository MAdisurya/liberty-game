using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager> {

	private int enemyCount = 0;
	private List<Character> m_Enemies;

	public int EnemyCount { get { return enemyCount; } }

	public EnemyManager() 
	{
		m_Enemies = new List<Character>();
	}

	public void RegisterEnemy(Character _Enemy)
	{
		m_Enemies.Add(_Enemy);
		enemyCount = m_Enemies.Count;
	}

	public void DeregisterEnemy(Character _Enemy)
	{
		m_Enemies.Remove(_Enemy);
		enemyCount = m_Enemies.Count;
	}
}
