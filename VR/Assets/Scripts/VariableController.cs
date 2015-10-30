using UnityEngine;
using System.Collections;

public class VariableController : MonoBehaviour {

    public float gameTime;
    public int numProjectiles;
    public bool loadGame = false;
    public float projectileSpeed = 100;
    private GameObject Panel;
	private Transform DFPos;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        Panel = GameObject.Find("Panel");
        Panel.SetActive(false);
		if (Application.loadedLevel.Equals(1)) {
			DFPos = GameObject.Find ("DragonFly").GetComponent<Transform>();
		}
    }
	
	// Update is called once per frame
	void Update () {
	    if (loadGame)
        {
            loadGame = false;
            Application.LoadLevel(1);
            Panel.SetActive(true);
		} 
        if (Application.loadedLevel.Equals(2)) {
            Panel.SetActive(false);
        }
		if (Application.loadedLevel.Equals(1)) {
			for (int i = 0; i < 5; i++) {
				Invoke("SpawnDragonfly", 2.0f);
		}
		}

	}

	public void SpawnDragonfly() {
		Instantiate (Dragonfly, DFPos.position, DFPos.rotation);
	}

}
