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
    public GameObject recourceMachine;
    public GameObject buildEffect;
    private TurretBluePrint turretToBuild;

   public bool CanBuild { get { return turretToBuild != null; } }
   public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
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
        GameObject buildEf = Instantiate(buildEffect, node.transform.position, Quaternion.identity);
        Debug.Log("Bild, money left" + PlayerStats.Money);
        Destroy(buildEf, 5f);
    }
}
