using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed;

    [Range(0,1f)]
    public float deadzone;
    public float speedOfRotation = 4;
    public float timeToAcceleration = 1;
    public float timeToDecceleration = 1;

     public float currentSpeedPlayer = 1;
     public LayerMask layer;
    private float gainPerSecond;
    private float lossPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        gainPerSecond = speed/timeToAcceleration;
        lossPerSecond = speed/timeToDecceleration;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 directionDeplacement = new Vector3(horizontal,vertical,0);
        if(directionDeplacement.magnitude>deadzone)
        {
            currentSpeedPlayer += gainPerSecond *Time.deltaTime;
            float angle = Vector3.SignedAngle(Vector3.up, directionDeplacement.normalized, Vector3.forward);
            float playerAngle =  Vector3.SignedAngle(Vector3.up,transform.up, Vector3.forward);
            angle = FindPositifAngle(angle,playerAngle);
            float angleBetween=  angle + (-1 * playerAngle);
            float signCurent = Mathf.Sign(angleBetween);

          if(Mathf.Abs(angleBetween)>2f)
          {
            playerAngle += signCurent* speedOfRotation*Time.deltaTime;
          }
        
            transform.rotation=  Quaternion.Euler(0,0,playerAngle);
        }else
        {
            currentSpeedPlayer -= lossPerSecond *Time.deltaTime;
            
        }
        currentSpeedPlayer = Mathf.Clamp(currentSpeedPlayer,0,speed);

            transform.position +=  transform.up.normalized * currentSpeedPlayer *Time.deltaTime;
        // if(!Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y,0) + directionDeplacement.normalized *0.5f ,directionDeplacement.normalized,speed*Time.deltaTime,layer))
        // {
        // }else
        // {
           
        //     Debug.LogWarning("Touch Wall");
        // }
    
    }

    public float FindPositifAngle(float angleToAim, float currentAngle)
    {
        if(angleToAim != 0)
        {

            float sign = Mathf.Sign(currentAngle); 
            float postifAngle = (angleToAim+(sign *180)) + (sign * 180);
            if(Mathf.Abs(postifAngle - currentAngle) <180)
            {
                return postifAngle;
            }else
            {
                return angleToAim;
            }
        }
        else
        {
            return 0;
        }
    }
}
