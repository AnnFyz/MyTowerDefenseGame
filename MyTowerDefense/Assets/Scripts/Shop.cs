using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint firstTurret;
    public TurretBluePrint secondTurret;

    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectFirstTurret()
    {
        buildManager.SelectTurretToBuild(firstTurret);
    }

    public void SelectSecondTurret()
    {
        buildManager.SelectTurretToBuild(secondTurret);
    }

}
