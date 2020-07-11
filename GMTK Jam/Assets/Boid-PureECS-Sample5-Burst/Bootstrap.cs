using UnityEngine;
using UnityEngine.Rendering;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Rendering;

namespace Boid.PureECS.Sample5
{

public class Bootstrap : MonoBehaviour 
{
    public static Bootstrap Instance 
    { 
        get; 
        private set; 
    }

    public static Param Param
    {
        get { return Instance.param; }
    }

    [SerializeField]
    int boidCount = 100;

    [SerializeField]
    Vector3 boidScale = new Vector3(0.1f, 0.1f, 0.3f);

    [SerializeField]
    Param param;

    [SerializeField]
    RenderMesh renderers;

    [SerializeField]
    Material mat1;
    [SerializeField]
    Material mat2;
    [SerializeField]
    Material mat3;
    [SerializeField]
    Material mat4;
        void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        var manager = World.Active.GetOrCreateManager<EntityManager>();
        var archetype = manager.CreateArchetype(
            typeof(Position),
            typeof(Rotation),
            typeof(Scale),
            typeof(Velocity),
            typeof(Acceleration),
            typeof(NeighborsEntityBuffer),
                typeof(RenderMesh));
            var random = new Unity.Mathematics.Random(853);

        for (int i = 0; i < boidCount; ++i)
        {
            int rnd = UnityEngine.Random.Range(0,4);
            var entity = manager.CreateEntity(archetype);
            if (rnd == 0)
            {
                renderers.material = mat1;
            }
            else if (rnd == 1)
            {
                renderers.material = mat2;
            }
            else if (rnd == 2)
            {
                renderers.material = mat3;
            }
            else if (rnd == 3)
            {
                renderers.material = mat4;
            }
            manager.SetComponentData(entity, new Position { Value = random.NextFloat3(1f) });
            manager.SetComponentData(entity, new Rotation { Value = quaternion.identity });
            manager.SetComponentData(entity, new Scale { Value = new float3(boidScale.x, boidScale.y, boidScale.z) });
            manager.SetComponentData(entity, new Velocity { Value = random.NextFloat3Direction() * param.initSpeed });
            manager.SetComponentData(entity, new Acceleration { Value = float3.zero });
            manager.SetSharedComponentData(entity, renderers);

            }
    }

    void OnDrawGizmos()
    {
        if (!param) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one * param.wallScale);
    }
}

}