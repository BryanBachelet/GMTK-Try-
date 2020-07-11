using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleWeapon : MonoBehaviour
{
  public  GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button0))
       {    
            GameObject oneBullet = Instantiate(ball,transform.position,transform.rotation);
            GameObject twoBullet =  Instantiate(ball,transform.position,transform.rotation);
            twoBullet.transform.eulerAngles = new Vector3(0,0,45 +  twoBullet.transform.eulerAngles.z);
            GameObject ThreeBullet =  Instantiate(ball,transform.position,transform.rotation);
            ThreeBullet.transform.eulerAngles = new Vector3(0,0,-45 +   ThreeBullet.transform.eulerAngles.z);

       }
    }
}
