using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    public float speed;
    float rndXMove;
    float rndYMove;
    Vector3 moveConstant;

    public float timeBeforeDestroy;
    float tempsEcouleLife;
    // Start is called before the first frame update
    void Start()
    {
        rndXMove = Random.Range(0, 1);
        rndYMove = Random.Range(0, 1);
        moveConstant = new Vector3(1.01f - rndXMove, 1.01f - rndYMove, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(tempsEcouleLife < timeBeforeDestroy)
        {
            tempsEcouleLife += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        transform.Translate(moveConstant * (speed * Time.deltaTime));
    }
}
