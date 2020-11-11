using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    //Transform taget;

    public float spawnRate = 1f;
    float time;

    float tMax = 3f;
    float tMin = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (!GameManager.instance.isGameover)
        {
            if (time > spawnRate)
            {
                time = 0;
                spawnRate = Random.Range(tMin, tMax);

                GameObject b = Instantiate(prefab, transform.position, transform.rotation);
                //b.transform.LookAt(taget);
            }
        }
    }
}
