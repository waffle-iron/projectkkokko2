using System;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Entitas;
using UnityEngine;

public class WalletConfig : UnityEntityConfig
{
    [Header("Wallet Settings")]
    [SerializeField]
    private ObscuredInt initValue = 0;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        contexts.game.SetWallet(initValue);
        contexts.game.walletEntity.isDoNotDestroyOnSceneChange = true;

        return contexts.game.walletEntity;
    }
}

