using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyScript : MonoBehaviour
{
    public GameObject leftClick;
    private bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                leftClick.SetActive(false);
                Time.timeScale = 1;
                isPlaying = true;
            }
        }
    }
}
