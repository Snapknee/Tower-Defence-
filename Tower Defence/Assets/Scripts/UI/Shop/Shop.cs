//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint RocketTurret;

    BuildManager buildManager;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void SelectRocketTurret()
    {
        Debug.Log("Standard Rocket Turret Selected");
        buildManager.SetTurretToBuild(buildManager.rocketTurretPrefab);
    }

}
