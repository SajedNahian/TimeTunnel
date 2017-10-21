using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointSpin : MonoBehaviour {
    private bool mainMenu;
    Spacecraft script;
	// Use this for initialization
	void Awake () {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            mainMenu = true;
        } else
        {
            script = GameObject.FindGameObjectWithTag("spaceCraft").GetComponent<Spacecraft>();
            mainMenu = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (mainMenu)
        {
            transform.Rotate(0, 3, 0, Space.World);
        } else
        {
            if (!script.gameOver)
            {
                transform.Rotate(0, 3, 0, Space.World);
            }
        }
	}
}
