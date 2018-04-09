using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class SoapEntityConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Soap Settings")]
    [SerializeField]
    private string id;
    [SerializeField, Tag]
    private string[] target;
    [SerializeField]
    private float speed = 1f;
    [SerializeField, Range(0f, 1f)]
    private float recoveryValue;
    [SerializeField]
    private float deltaAmountToComplete = 100f;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddSoap(id, recoveryValue);
        gameEty.AddWipe(deltaAmountToComplete);
        gameEty.AddTargetTag(target);
        gameEty.isCollidable = true;
        gameEty.AddMoveable(speed);

        return gameEty;
    }
}