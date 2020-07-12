using UnityEngine;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Boid.OOP
{

public class Simulation : MonoBehaviour
{
    [SerializeField]
    public int boidCount = 100;

    [SerializeField]
    GameObject boidPrefab;

    [SerializeField]
    public Param param;

    List<Boid> boids_ = new List<Boid>();

        [SerializeField]
        public Vector3 velocity;
        Vector3 lastFrame;
    public ReadOnlyCollection<Boid> boids
    {
        get { return boids_.AsReadOnly(); }
    }

    void AddBoid()
    {
        var go = Instantiate(boidPrefab, Random.insideUnitSphere, Random.rotation);
        go.transform.SetParent(transform);
        var boid = go.GetComponent<Boid>();
        boid.simulation = this;
        boid.param = param;
        boids_.Add(boid);
    }

    void RemoveBoid()
    {
        if (boids_.Count == 0) return;

        var lastIndex = boids_.Count - 1;
        var boid = boids_[lastIndex];
        Destroy(boid.gameObject);
        boids_.RemoveAt(lastIndex);
    }

    void Update()
    {
        velocity = transform.position - lastFrame;
        while (boids_.Count < boidCount)
        {
            AddBoid();
        }
        while (boids_.Count > boidCount)
        {
            RemoveBoid();
        }
            lastFrame = transform.position;
    }

    void OnDrawGizmos()
    {
        if (!param) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one * param.wallScale);
    }
}

}
