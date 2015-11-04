using UnityEngine;
using System.Collections;

public class Instantiate2 : MonoBehaviour {
	public Transform Dragonfly;
	public Transform Bat;
	public Transform Snake;
	public Transform startPoint;
	private Vector3 spawn;
	private Vector3 spawnLoc;
	private int probability;
	private VariableController variables;
	// Use this for initialization
	void Start () {
		spawn = new Vector3(0.0f, 2.0f, 20.0f);
		variables = GameObject.Find("Variables").GetComponent<VariableController>();
	}
	
	// Update is called once per frame
	void Update () {
		spawnFunc();
	}
	
	public void spawnFunc() {
		probability = new System.Random().Next(0, 10);
		spawnLoc = new Vector3 (41.77f, Random.Range (-.06f, 3.2f) , Random.Range (-21.25f, -17.45f));
		if (probability < 3 && variables.numDragonfly2 > 0) {
			Instantiate(Dragonfly, spawnLoc, startPoint.rotation);
			variables.numDragonfly2--;
		//	Debug.Log("Dragonfly");
		} else if (probability < 6 && variables.numBat2 > 0) {
			Instantiate(Bat, spawnLoc, startPoint.rotation);
			variables.numBat2--;
			Debug.Log("Bat");
		} else if (variables.numSnakes2 > 0) {
			Instantiate(Snake, spawnLoc, startPoint.rotation);
			variables.numSnakes2--;
			Debug.Log("Snake");
		}
		
	}
	
}