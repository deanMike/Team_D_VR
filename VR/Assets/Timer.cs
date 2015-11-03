using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    private VariableController variables;
    public float timer;
    private Text timerObj;
	private int secElapsed;

    // Use this for initialization
	void Start () {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        timer = variables.gameTime;
        timerObj = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.loadedLevel == 1) {
            timer -= Time.deltaTime;
            timerObj.text = ((int)timer).ToString();
            if (timer <= 0) {
                timer = 0;
                Application.LoadLevel(2);
            }
        }
	}
}
