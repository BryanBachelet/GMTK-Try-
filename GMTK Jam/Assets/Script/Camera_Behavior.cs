using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behavior : MonoBehaviour
{
    public GameObject player ; 
    public float speed;
    public float cameraZDistanceForOne = 10;
    [Range(0,100)]
    public int numberOfAgent = 1;
    public int minimumAgentNumber;
    public float gainZDistancePerAgent = 0.5f;
    [Header("Test Variable")]
    public GameObject agent;

    private float currentCameraZDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Joystick1Button0))
       {
            Vector3 newPos = new Vector3(Random.Range(-2,2),Random.Range(-2,2),0);
            Instantiate(agent,player.transform.position + newPos,player.transform.rotation, player.transform);
            numberOfAgent++;
       } 
       if(numberOfAgent>minimumAgentNumber)
       {
        currentCameraZDistance =  cameraZDistanceForOne +( numberOfAgent-minimumAgentNumber) *gainZDistancePerAgent;
       }
        Vector3 nextCameraPosition = new Vector3(player.transform.position.x,player.transform.position.y,-currentCameraZDistance);
        transform.position = Vector3.Lerp(transform.position,nextCameraPosition,speed * Time.deltaTime);
    }
}
