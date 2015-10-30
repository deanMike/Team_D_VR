using UnityEngine;
using System.Collections;

public class Freeze : MonoBehaviour {
    private Transform character;
    VariableController variables;
    private float speed;
    AudioSource sound;
	Transform objTrans;

	// Use this for initialization
	void Start () {
        sound = gameObject.GetComponent<AudioSource>();
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        speed = variables.projectileSpeed;
        character = Camera.main.transform;
		objTrans = gameObject.transform;
    }

    // Update is called once per frame
    void Update() {
		//transform.position = new Vector3(transform.position.x, character.position.y, transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(character.position.x * (float)(new System.Random().NextDouble()), character.position.y * (float)(new System.Random().NextDouble()), character.position.z + 1), Time.deltaTime * speed);
        if (transform.position.Equals(new Vector3(character.position.x, character.position.y, character.position.z + 1))) {
            Destroy(gameObject);
        }
    }
    public void Petrify() {
        if (speed > 1) {
            speed -= speed / 4;
        } else {
            speed = 0;
			Rigidbody rigid = gameObject.GetComponent<Rigidbody>();
			//rigid.mass = 1;
			//rigid.mass *= 1000;
			rigid.useGravity = true;
			Invoke ("DestroyObj", 3);
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
