using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

[AlwaysSynchronizeSystem]
public class RobotRotationSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDebs)
    {

        Entities.ForEach((ref Rotation rotation, in RobotInputData input) =>
        {
            float3 direction = float3.zero;
            direction.xz = input.direction;

            //Magnitud cuadrada.
            if (math.distancesq(float3.zero, direction) > 0)
                rotation.Value = quaternion.LookRotation(direction, math.up());

        }).Run();

        return default;
    }
}
