using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace EMJCharacterStates {
	public class StateManager : Singleton<StateManager> {

		public List<EMJStateManager> _stateManagers;

		void Awake()
		{
			Assert.IsNotNull(_stateManagers);
		}

		void Update()
		{
			foreach (EMJStateManager stateManager in _stateManagers) 
			{
				stateManager.ChangeState();
			}
		}
	}
}