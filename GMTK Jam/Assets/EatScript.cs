using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatScript : MonoBehaviour
{
    public LayerMask foodlayer;
    Boid.OOP.Simulation mySimuScript;
    Player_Controller myPlayerControler;
    // Start is called before the first frame update
    void Start()
    {
        mySimuScript = gameObject.GetComponent<Boid.OOP.Simulation>();
        myPlayerControler = gameObject.GetComponent<Player_Controller>(); 
        mySimuScript.param.wallScale = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] foodInRange = Physics.OverlapSphere(transform.position, 1.5f, foodlayer);
        if(foodInRange.Length > 0)
        {
            for(int i = 0; i <foodInRange.Length; i++)
            {
                mySimuScript.boidCount += 10;
                mySimuScript.param.wallScale += 0.23f;
                myPlayerControler.speed = 15;
                Destroy(foodInRange[i].gameObject);

            }
        }
    }

}
