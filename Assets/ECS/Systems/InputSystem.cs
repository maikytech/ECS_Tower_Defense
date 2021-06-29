using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class InputSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDebs)
    {
        float2 dir = math.float2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Entities.ForEach((ref InputData input) =>
        {
            input.direction = dir;

        }).Run();

        return default;
    }
}
