using UnityEngine;
using System.Collections;

public class Freeze : MonoBehaviour {
    private Transform character;
    VariableController variables;
    private float speed;
    private bool slowDown = false;
    AudioSource sound;


	// Use this for initialization
	void Start () {
        sound = gameObject.GetComponent<AudioSource>();
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        speed = variables.projectileSpeed;
        character = Camera.main.transform;
    }

    // Update is called once per frame
    void Update() {
		//transform.position = new Vector3(transform.position.x, character.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(character.position.x, character.position.y, character.position.z + 1), Time.deltaTime * speed);

        if (transform.position.Equals(new Vector3(character.position.x, character.position.y, character.position.z + 1))) {
            Destroy(gameObject);
        }
    }
    public void Petrify() {
        if (speed > 0) {
            speed -= speed / 10;
        } else {
            speed = 0;
			Rigidbody rigid = gameObject.AddComponent<Rigidbody>();
			rigid.useGravity = true;
			Invoke ("DestroyObj", 3.0f);
        }
    }

	public void DestroyObj() {
		Destroy (gameObject);
	}
	
}

//Pseudo Code
/*
While an object is being looked at (Raycast hit), slow down until it stops.
*/
