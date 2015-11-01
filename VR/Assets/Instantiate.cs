using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour {
    public Transform Dragonfly;
    public Transform Bat;
    public Transform Snake;
    public Transform startPoint;
    private Vector3 spawn;
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
        if (probability < 3 && variables.numDragonfly > 0) {
            Instantiate(Dragonfly, startPoint.position, startPoint.rotation);
            variables.numDragonfly--;
            Debug.Log("Dragonfly");
        } else if (probability < 6 && variables.numBat > 0) {
            Instantiate(Bat, startPoint.position, startPoint.rotation);
            variables.numBat--;
            Debug.Log("Bat");
        } else if (variables.numSnakes > 0) {
            Instantiate(Snake, startPoint.position, startPoint.rotation);
            variables.numSnakes--;
            Debug.Log("Snake");
        }

    }

}
