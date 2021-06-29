using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class EnemyMovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;
 
        JobHandle jobHandle = Entities.ForEach((ref Translation translation, in EnemyData enemyData) => {

            translation.Value.z = (translation.Value.z + (enemyData.enemySpeed2 * deltaTime) * -1f);

        }).Schedule(inputDeps);

        return jobHandle;
    }
}
