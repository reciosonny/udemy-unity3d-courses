using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PipeCollector : MonoBehaviour {

	private List<GameObject> pipeHolders;
	private float distance = 3.5f;
	private float lastPipeX;
	private float pipeMin = -1.5f;
	private float pipeMax = 2.4f;

	void Awake() {

		pipeHolders = GameObject.FindGameObjectsWithTag ("PipeHolder").ToList();
		lastPipeX = pipeHolders [0].transform.position.x;
		Debug.Log (pipeHolders.Count());

		var lastPipeHolder = pipeHolders [pipeHolders.Count - 1];
//		lastPipeX = tempPosition.x;

		GameObject pipeClone = null;


		for (int i = 0; i < 4; i++) {
			if (pipeClone == null) {
				pipeClone = Instantiate (lastPipeHolder);
			} else {
				pipeClone.name = "clone";
				pipeClone = Instantiate (pipeClone);
			}

			Vector3 tempPosition = pipeClone.transform.position;

			tempPosition.x += distance;
			tempPosition.y = Random.Range (pipeMin, pipeMax); //randomize y-axis pipe
			lastPipeX = tempPosition.x;
			Debug.Log ("Position: "+lastPipeX);

			pipeClone.transform.position = tempPosition;
			pipeHolders.Add (pipeClone);
		}

//		for (int i = 0; i < pipeHolders.Count; i++) {
//			Vector3 temp = pipeHolders [i].transform.position;
//			temp.x += lastPipeX + distance;
//			temp.y = Random.Range (pipeMin, pipeMax); //randomize y-axis pipe
//			pipeHolders [i].transform.position = temp;
//		}
			
		for (int i = 0; i < pipeHolders.Count; i++) {
			if (lastPipeX < pipeHolders[i].transform.position.x) {
				lastPipeX = pipeHolders [i].transform.position.x;
			}
		}


		Debug.Log ("Pipecollider instantiate");
	}

	void OnTriggerEnter2D(Collider2D target) {
		Debug.Log ("pipe holder collided");
		if (target.tag == "PipeHolder") {
			Vector3 temp = target.transform.position;

			temp.x = lastPipeX + distance;
			temp.y = Random.Range (pipeMin, pipeMax);

			target.transform.position = temp;

			lastPipeX = temp.x;
		}
	}


}
