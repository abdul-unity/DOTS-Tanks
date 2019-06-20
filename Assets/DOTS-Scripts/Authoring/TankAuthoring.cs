﻿using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class TankAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public int playerId;
    public float moveSpeed = 12f;
    public float turnSpeed = 180f;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new TankPlayer
        {
            PlayerId = playerId,
            Score = 0,
        });
        dstManager.AddComponentData(entity, new TankMovementStats
        {
            MoveSpeed = moveSpeed,
            TurnSpeed = turnSpeed,
        });
        dstManager.AddComponentData(entity, new PlayerInputState());
        dstManager.AddComponent(entity, typeof(CameraTarget));
        dstManager.AddComponent(entity, typeof(Prefab));
    }
}
