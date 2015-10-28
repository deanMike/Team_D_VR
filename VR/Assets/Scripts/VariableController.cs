using UnityEngine;
using System.Collections;

public class VariableController : MonoBehaviour {

    public float gameTime;
    public int numProjectiles;
    public bool loadGame = false;
    public float projectileSpeed = 100;
    private GameObject Panel;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        Panel = GameObject.Find("Panel");
        Panel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	    if (loadGame)
        {
            loadGame = false;
            Application.LoadLevel(1);
            Panel.SetActive(true);
        }
	}
}
