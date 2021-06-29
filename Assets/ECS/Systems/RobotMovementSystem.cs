using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

[AlwaysSynchronizeSystem]
public class RobotMovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDebs)
    {
        float deltaTime = Time.DeltaTime;

         Entities
            .WithoutBurst()
            .ForEach((ref Translation position, in RobotSpeedData speed, in RobotInputData input) =>
            {
                position.Value.xz += input.direction * speed.robotSpeed * deltaTime;

            }).Run();

        return default;
    }
}

