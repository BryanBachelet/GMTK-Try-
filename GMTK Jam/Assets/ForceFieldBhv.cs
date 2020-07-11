using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldBhv : MonoBehaviour
{
    public float radiusAttract;
    public float strenghAttract;
    public float radiusExtract;
    public float strenghExtracts;
    public bool isAttract = true;
    private ParticleSystemForceField myForceFieldComponent;
    // Start is called before the first frame update
    void Start()
    {
        myForceFieldComponent = gameObject.GetComponent<ParticleSystemForceField>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttract)
        {
            myForceFieldComponent.endRange = radiusAttract;
            myForceFieldComponent.gravity = strenghAttract;
        }
        else
        {
            myForceFieldComponent.endRange = radiusExtract;
            myForceFieldComponent.gravity = strenghExtracts;
        }
    }

    private void OnDrawGizmos()
    {
        if(isAttract)
        {
            Gizmos.color = new Vector4(0, 1, 0, 0.5f);
            Gizmos.DrawSphere(transform.position, radiusAttract);
        }
        else
        {
            Gizmos.color = new Vector4(1, 0, 0, 0.5f);
            Gizmos.DrawSphere(transform.position, radiusExtract);
        }

    }

}
