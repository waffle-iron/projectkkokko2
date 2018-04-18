using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UniRx;

public class GridApartmentEntityConfig : UnityEntityConfig
{
    //enter serialized fields here
    [Header("Grid Settings")]
    [SerializeField]
    private string _gridID;
    [SerializeField]
    private Vector2 _size;
    [SerializeField]
    private ApartmentItemType _acceptedType;

    protected override IEntity CustomCreate (Contexts contexts)
    {
        var gameEty = contexts.game.CreateEntity();
        gameEty.AddGrid(_gridID, _size);
        gameEty.AddApartmentItem(new ApartmentItemData(_acceptedType, ""));

        var newDataSet = new Dictionary<Vector2, ApartmentItemData>();
        var keys = _size.ToArray();
        foreach (var key in keys)
        {
            newDataSet.Add(key, ApartmentItemData.Empty);
        }

        gameEty.AddGridApartmentData(newDataSet);

        return gameEty;
    }
}

