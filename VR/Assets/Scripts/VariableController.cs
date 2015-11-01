using UnityEngine;

public class VariableController : MonoBehaviour {
    public float gameTime;
    public int numProjectiles;
    public bool loadGame = false;
    public float projectileSpeed = 100;
    private GameObject Panel;
    private Transform DFPos;
    public int numBat, numDragonfly, numSnakes;

    // Use this for initialization
    private void Start() {
        DontDestroyOnLoad(gameObject);
        Panel = GameObject.Find("Panel");
        Panel.SetActive(false);
    }

    // Update is called once per frame
    private void Update() {
        if (loadGame) {
            loadGame = false;
            Application.LoadLevel(1);
            Panel.SetActive(true);
        }
        if (Application.loadedLevel.Equals(2)) {
            Panel.SetActive(false);
        }
    }

}