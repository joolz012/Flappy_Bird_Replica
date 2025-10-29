using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float spawnTimer;
    public GameObject pipeObj;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiatePipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-2, 3.5f), 0);
        GameObject pipe = Instantiate(pipeObj, spawnPos, Quaternion.identity);

        Destroy(pipe, 10);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnTimer()
    {
        while (true)
        {
            InstantiatePipe();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
