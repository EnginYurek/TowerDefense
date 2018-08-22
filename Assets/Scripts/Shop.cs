using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void purchaseStandardTurret()
    {
        Debug.Log("Standart Turret Selected");
        buildManager.setTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void purchaseMissleLauncher()
    {
        Debug.Log("Missle Launcher Selected");
        buildManager.setTurretToBuild(buildManager.mislleLauncherPrefab);
    }

}
