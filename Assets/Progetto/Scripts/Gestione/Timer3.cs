using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer3 : MonoBehaviour {

    public Text time;
    float timer;
    GameManager gm;
    public GameObject gestoreGroucho;

    // Use this for initialization
    void Start()
    {

        timer = 90f;
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gestoreGroucho.GetComponent<Generazione3>().find && gestoreGroucho.GetComponent<Generazione3>().find2)
        {
            timer -= Time.deltaTime;
            int second = (int)(timer % 90);
            if (second > 0)
            {
                time.text = "Time:" + second;
            }
            if (second == 0)
            {

                time.text = "Time:" + 0;
                gm.endGame();

            }

        }

    }
}
