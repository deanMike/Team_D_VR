using UnityEngine;

public class Freeze : MonoBehaviour {
    private Transform character;
    private VariableController variables;
    private float speed;
    private AudioSource sound;
    private Transform objTrans;
    public AudioClip[] sounds;
	private float t = 0;
	private float duration = 1;

    // Use this for initialization
    private void Start() {
        sound = gameObject.GetComponent<AudioSource>();
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        speed = variables.projectileSpeed;
        character = Camera.main.transform;
        objTrans = gameObject.transform;
    }

    // Update is called once per frame
    private void Update() {
        transform.localPosition = Vector3.MoveTowards(transform.position, new Vector3(character.position.x, character.position.y, character.position.z + 0.5f), Time.deltaTime * speed);
        if (transform.localPosition.Equals(new Vector3(character.position.x, character.position.y, character.position.z + 0.5f))) {
            DestroyObj();
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
			Debug.Log(gameObject.name.Substring(0));
			gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, t);
		}
		if (t < 1) { // while t below the end limit...
			// increment it at the desired rate every update:
			t += Time.deltaTime / duration;
		}
		Invoke("DestroyObj", 3);
	}

	public void DestroyObj() {
		Destroy(gameObject);
		Debug.Log(gameObject.name.Substring(0,1));
		switch (gameObject.name.Substring(0,1)) {
		case "S":
			variables.numSnakes++;
			break;
		case "D":
			variables.numDragonfly++;
			break;
		case "B":
			variables.numBat++;
			break;
		default:
			break;
		}
}
}