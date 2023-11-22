//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint RocketTurret;
    public TurretBlueprint LaserTurret;

    BuildManager buildManager;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectRocketTurret()
    {
        Debug.Log("Standard Rocket Turret Selected");
        buildManager.SelectTurretToBuild(RocketTurret);
    }

    public void SelectLaserTurret()
    {
        Debug.Log("Standard Laser Turret Selected");
        buildManager.SelectTurretToBuild(LaserTurret);
    }

}
