using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {
    private VariableController variables;
	// Use this for initialization
	void Start () {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (gameObject.GetComponent<Renderer>().material.color.Equals(Color.red))
        {
            variables.loadGame = true;
        }
	}
}
