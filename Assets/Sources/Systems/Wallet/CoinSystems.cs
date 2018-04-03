using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class CoinSystems : Feature
{
    public CoinSystems (Contexts contexts) : base("Coin Systems")
    {
        //Add(system here);
        Add(new WalletAddCoinInputReactiveSystem(contexts));
        Add(new WalletOverallAddCoindInputReactiveSystem(contexts));

        Add(new WalletAddCoinCommandReactiveSystem(contexts));
    }
}