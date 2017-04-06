using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyCoroutine {

	/// <summary>
	/// Solution/workaround for using 'Time.timeScale = 0f' inside Awake function in gameplaycontroller which causes black screen
	/// </summary>
	/// <returns>The for real seconds.</returns>
	/// <param name="time">Time.</param>
	public static IEnumerator WaitForRealSeconds(float time) {
		float start = Time.realtimeSinceStartup; //time since game started

		while (Time.realtimeSinceStartup < (start + time)) {
			yield return null;
		}

	}

}
