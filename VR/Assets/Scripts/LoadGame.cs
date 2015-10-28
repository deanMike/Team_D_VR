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
            player.transform.position = new Vector3(1.26f, 0.31f, 18.5f);
            player.transform.localRotation = new Quaternion(player.transform.localRotation.x, player.transform.localRotation.y + 180, player.transform.localRotation.z, player.transform.localRotation.w);
        }
	}
}
