using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed;

    [Range(0,1f)]
    public float deadzone;
    public float speedOfRotation = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 directionDeplacement = new Vector3(horizontal,vertical,0);
        if(directionDeplacement.magnitude>deadzone)
        {
          
            transform.position +=  transform.up.normalized * speed *Time.deltaTime;
            float angle = Vector3.SignedAngle(Vector3.up, directionDeplacement.normalized, Vector3.forward);
            float playerAngle =  Vector3.SignedAngle(Vector3.up,transform.up, Vector3.forward);
            angle = FindPositifAngle(angle,playerAngle);
            angle = Mathf.Lerp(playerAngle,angle,speedOfRotation*Time.deltaTime);
            transform.rotation=  Quaternion.Euler(0,0,angle);
        }
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
