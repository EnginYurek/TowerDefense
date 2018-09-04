using UnityEngine;

public class BuildManager : MonoBehaviour {

    private TurretBlurprint turretToBuild;
    private Node selectedNode;

    public static BuildManager instance;
    public GameObject buildEffect;
    public NodeUI nodeUI;

    public GameObject sellEffect;

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

    public void selectNode(Node node)
    {
        if (selectedNode == node)
        {
            deselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.setTarget(node);
    }

    public void deselectNode()
    {
        selectedNode = null;
        nodeUI.hide();
    }
    public void selectTurretToBuild(TurretBlurprint turret)
    {
        turretToBuild = turret;
        deselectNode();
    }

    public TurretBlurprint getTurretToBuild()
    {
        return turretToBuild;
    }

}
