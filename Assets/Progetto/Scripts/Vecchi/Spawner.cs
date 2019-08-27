using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Spawner : Photon.MonoBehaviour
{
    public GameObject enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    private GameObject enemy;
    private static bool active;

    void Start()
    {
        active = false;
        stop = true;
        StartCoroutine(waitSpawner());
    }


    void Update()
    {
        active = GameObject.Find("ImageTarget").GetComponent<DefaultTrackableEventHandler>().find;
        if (active && PhotonNetwork.player.NickName.Equals("Player1"))
        {
            stop = false;
            Debug.Log("eccomi");
        }
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    public IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)
            {
                float a = RandomPosX();
                Vector3 spawnPosition = new Vector3(a, 0, Random.Range(-spawnValues.z, spawnValues.z));
                enemy = (GameObject)PhotonNetwork.Instantiate(enemies.name, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), 0);
                enemy.transform.localPosition = spawnPosition;
                enemy.transform.localEulerAngles = new Vector3(0f, 270f, 0f);
                yield return new WaitForSeconds(spawnWait);
            } 
    }

    public static float RandomPosX()
    {
        return Random.value < 0.5 ? -47 : 47;
    }


}


