using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApartmentPositionsReference : MonoBehaviour {

    private static ApartmentPositionsReference _instance;

    public static ApartmentPositionsReference Instance
    {
        get {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ApartmentPositionsReference>();
            }
            return _instance;
        }
    }

    public Transform LEFT_SPAWN_BOUNDS;
    public Transform RIGHT_SPAWN_BOUNDS;    
}
