using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    private VariableController variables;
    private float timer;
    private Text timerObj;

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
            }
        }
	}
}
