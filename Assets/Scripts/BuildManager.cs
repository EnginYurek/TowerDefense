using UnityEngine;

public class BuildManager : MonoBehaviour {

    private GameObject turretToBuild;

    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one build manager in the scene");
            return;
        }

        instance = this;
    }


    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }

    public void setTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }


  
}
