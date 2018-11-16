using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : Singleton<LevelManager> {

	public void GoToNextScene()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		SceneManager.LoadScene(currentSceneIndex + 1);
	}

	public void GoToScene(string _SceneName)
	{
		SceneManager.LoadScene(_SceneName);
	}
}
