using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        instance = this; //Singleton

        if (instance != null)
        {
            return;
        }
    }

    public GameObject firtsTurretPrefab;
    public GameObject secondTurretPrefab;

    private TurretBluePrint turretToBuild;

   public bool CanBuild { get { return turretToBuild != null; } }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn (Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position, Quaternion.identity);
        node.turret = turret;
        Debug.Log("Bild, money left" + PlayerStats.Money);
    }
}
