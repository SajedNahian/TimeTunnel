using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    private Rigidbody myBody;

    // Use this for initialization
    void Awake () {
        Time.timeScale = 1f;
        myBody = this.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= 35.6f)
        {
            myBody.AddForce(new Vector3(0, Random.Range(.2f,.4f), 0), ForceMode.Impulse);
        }
	}

    public void PlayButton ()
    {
        Application.LoadLevel("MainScene");
    }
}
