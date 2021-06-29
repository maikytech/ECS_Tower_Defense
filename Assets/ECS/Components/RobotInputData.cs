using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct RobotInputData : IComponentData
{
    public float2 direction;   
}
