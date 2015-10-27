using UnityEngine;
using System.Collections;

public class Freeze : MonoBehaviour {
    private Transform character;
    VariableController variables;
    private float speed;
    private bool slowDown = false;
	// Use this for initialization
	void Start () {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        speed = variables.projectileSpeed;
    }

    // Update is called once per frame
    void Update() {
        character = Camera.main.transform;
        transform.position = new Vector3(transform.position.x, character.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(character.position.x, character.position.y + 30, character.position.z + 5), Time.deltaTime * speed);
    }
    public void Petrify() {
        if (speed > 0) {
            speed -= speed / 4;
        } 
    }
}

//Pseudo Code
/*
While an object is being looked at (Raycast hit), slow down until it stops.
*/
