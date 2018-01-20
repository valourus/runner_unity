using System.Collections;
using System.Collections.Generic;
using Entitas.Unity;
using Entitas.VisualDebugging.Unity;
using UnityEngine;
using Sources.Utils;

public class Destroyer : MonoBehaviour {

	public GeneratePlace place;
	
	void OnTriggerEnter(Collider other) {
		if(other != null) {
			Destroy(other.gameObject.transform.parent.gameObject);
			//Destroy(other.gameObject);
			Contexts.sharedInstance.input.CreateEntity().AddGenerateObstacle(place);
		} 
	}
}
