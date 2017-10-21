using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    private int nextObstacleType;
    private float currentZcor = -51.3f;
    private float yCor = 21.40112f;
    [SerializeField]
    private GameObject obs1, obs2;
    private bool gameBegin;
    private int countdown = 2;
	// Use this for initialization
	void Start () {
        gameBegin = true;
        float xCor = Random.Range(-18f, 26f);
        Vector3 temp = new Vector3(xCor, yCor, currentZcor);
        Instantiate(obs1, temp, transform.rotation);
        nextObstacleType = 2;
        currentZcor += 160f;
        nextObstacle();
        nextObstacle();
        nextObstacle();
        nextObstacle();
        gameBegin = false;
    }
	
	// Update is called once per frame
	public void nextObstacle ()
    {

        if (nextObstacleType == 1)
        {
            //Destroy(GameObject.FindGameObjectWithTag("Obstacle1"));
            if (!gameBegin && (countdown == 0))
            {
                //destroyFirstObsOfType("Obstacle2");
                StartCoroutine(destroyFirstObsOfType("Obstacle2"));
            } else if (!(countdown == 0) && !gameBegin)
            {
                countdown--;
            }
            float xCor = Random.Range(18f, 60f);
            Vector3 temp = new Vector3(xCor, yCor, currentZcor);
            Instantiate(obs1, temp, transform.rotation);
            nextObstacleType = 2;
            currentZcor += 160f;
        } else
        {
            //Destroy(GameObject.FindGameObjectWithTag("Obstacle2"));
            if (!gameBegin && (countdown == 0))
            {
                //destroyFirstObsOfType("Obstacle1");
                StartCoroutine(destroyFirstObsOfType("Obstacle1"));
            } else if (!(countdown == 0) && !gameBegin)
            {
                countdown--;
            }
            float xCor = Random.Range(18f, 60f);
            Vector3 temp = new Vector3(xCor, yCor, currentZcor);
            Instantiate(obs2, temp, transform.rotation);
            nextObstacleType = 1;
            currentZcor -= 10f;
        }
    }

    IEnumerator destroyFirstObsOfType (string obsName)
    {
        yield return new WaitForSeconds(4f);
        GameObject[] listOfObs = GameObject.FindGameObjectsWithTag(obsName);
        GameObject zMinObj = listOfObs[0];
        for (int i = 1; i < listOfObs.Length; i++)
        {
            if (listOfObs[i].transform.position.z < zMinObj.transform.position.z)
            {
                zMinObj = listOfObs[i];
            }
        }
        Destroy(zMinObj);
    }
}
