﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

	private static T _instance;

	public static T Instance { get { return _instance; } }

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = FindObjectOfType<T>();
			if (_instance == null)
			{
				GameObject obj = new GameObject();
				_instance = obj.AddComponent<T>();
			}
		}
	}
}
