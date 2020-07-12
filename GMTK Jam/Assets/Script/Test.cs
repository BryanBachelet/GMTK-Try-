using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float start = 0;

    public float velocity;
    
    public float smoothTime;
    public float finish = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        float t = (Time.time - 0) / 5;
      //  start = Mathf.SmoothStep(start,finish,t); // Autre méthode smooth
     //  start =  Mathf.SmoothDamp(start,finish,ref velocity,smoothTime); // permet de smooth une valeur
        
    }
}
