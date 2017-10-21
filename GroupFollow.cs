using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupFollow : MonoBehaviour {

    [SerializeField]
    private GameObject spaceShip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = transform.position;
        temp = spaceShip.transform.position;
        temp.y = 0f;
        transform.position = temp;
	}
}
