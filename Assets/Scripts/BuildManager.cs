using UnityEngine;

public class BuildManager : MonoBehaviour {

    private GameObject turretToBuild;

    public static BuildManager instance;

    public GameObject standardTurretPrefab;


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


    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }
}
