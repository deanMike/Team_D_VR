using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {
    private VariableController variables;
    // Use this for initialization

    private GameObject player;
	void Start () {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    if (gameObject.GetComponent<Renderer>().material.color.Equals(Color.red))
        {
            variables.loadGame = true;
            player.transform.position = new Vector3(1366, -1500, -18716);
        }
	}
}
