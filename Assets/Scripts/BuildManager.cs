using UnityEngine;

public class BuildManager : MonoBehaviour {

    private TurretBlurprint turretToBuild;

    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    public GameObject mislleLauncherPrefab;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one build manager in the scene");
            return;
        }

        instance = this;
    }

    public bool canBuild { get { return turretToBuild != null; } }

    public bool hasMoney { get { return PlayerStats.money >=  turretToBuild.cost; } }

    public void selectTurretToBuild(TurretBlurprint turret)
    {
        turretToBuild = turret;
    }

    public void buildTurretOn(Node node)
    {
        if (PlayerStats.money <= turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.getBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build! Money left: " + PlayerStats.money);
    }
  
}
