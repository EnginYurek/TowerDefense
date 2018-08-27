﻿using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlurprint standartTurret;
    public TurretBlurprint missleLauncher;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void selectStandardTurret()
    {
        Debug.Log("Standart Turret Selected");
        buildManager.selectTurretToBuild(standartTurret);
    }

    public void selectMissleLauncher()
    {
        Debug.Log("Missle Launcher Selected");
        buildManager.selectTurretToBuild(missleLauncher);
    }

}
