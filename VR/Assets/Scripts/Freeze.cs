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
	private float secElapsed;
	private Timer timer;
	//private int even = 6;

    // Use this for initialization
    private void Start() {
		timer = GameObject.Find ("Timer").GetComponent<Timer> ();
        sound = gameObject.GetComponent<AudioSource>();
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        speed = variables.projectileSpeed;
        character = Camera.main.transform;
        objTrans = gameObject.transform;

		gameObject.transform.localEulerAngles = new Vector3 (356f, 93.6438f, 278.9371f);


    }

    // Update is called once per frame
    private void Update() {
		secElapsed = Time.timeSinceLevelLoad;
		transform.localPosition = Vector3.MoveTowards(transform.position, new Vector3(Random.Range(-5.0f, 5.5f), Random.Range(-1.0f, 5.5f) - 2, character.position.z + 0.5f), Time.deltaTime * speed);
        if (transform.localPosition.z == character.position.z + 0.5f) {
            DestroyObj();

			switch (gameObject.name.Substring (0, 1)) {
			case "S":
				//if ((even % 7) == 0){
				timer.timer += 1;
				//}
				break;
			case "D":
				//if ((even % 7) == 0){
				timer.timer -= 1;
				//}
				break;
			case "B":
				//if ((even % 7) == 0){
				timer.timer -= 1;
				//}
				break;
			default:
				break;
			} 
        }

    }

	public void Petrify() {
			speed = 0;
			Rigidbody rigid = gameObject.GetComponent<Rigidbody>();
			//rigid.mass = 1;
			//rigid.mass *= 1000;
			rigid.useGravity = true;
			Debug.Log(gameObject.name.Substring(0));
			gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, t);

			if (t < 1) { // while t below the end limit...
				// increment it at the desired rate every update:
				t += Time.deltaTime / duration;
			}
			Invoke("DestroyObj", 3);
	}

	public void DestroyObj() {
		Destroy(gameObject);
		
		//even++;
		
		Debug.Log(gameObject.name.Substring(0,1));
		switch (gameObject.name.Substring (0, 1)) {
		case "S":
			//if ((even % 7) == 0){
				for (int i = 0; i < (secElapsed / 20); i++) {
					variables.numSnakes++;
				}
			//}
			break;
		case "D":
			//if ((even % 7) == 0){
			for (int i = 0; i < (secElapsed / 20); i++){
					variables.numDragonfly++;

				}
			//}
			break;
		case "B":
			//if ((even % 7) == 0){
			for (int i = 0; i < (secElapsed / 20); i++){
					variables.numBat++;
				}
			//}
			break;
		default:
			break;
		}
	}
}