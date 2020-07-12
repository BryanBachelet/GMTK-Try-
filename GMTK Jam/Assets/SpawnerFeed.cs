
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFeed : MonoBehaviour
{
    public float randomRangeSpawn;
    public float tempsBtwnSpawn;
    float tempsEcouleSpawn = 0;

    public GameObject foodPrefab;
    public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tempsEcouleSpawn < tempsBtwnSpawn)
        {
            tempsEcouleSpawn += Time.deltaTime;
        }
        else
        {
            float PosSpawn = Random.Range(-randomRangeSpawn, randomRangeSpawn);
            tempsEcouleSpawn = 0;
            Instantiate(foodPrefab, new Vector3(playerPos.position.x + PosSpawn, playerPos.position.y + PosSpawn, 0), transform.rotation);
        }
    }
}
