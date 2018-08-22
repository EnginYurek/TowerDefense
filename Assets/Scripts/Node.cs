
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {


    public Color hoverColor;

    private Renderer rend;
    private Color initialColor;

    private GameObject turret;

    public Vector3 positionOffset;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();

        initialColor = rend.material.color;

        buildManager = BuildManager.instance;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.getTurretToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }


    private void OnMouseExit()
    {
        rend.material.color = initialColor;
    }

    private void OnMouseDown()
    {
        if (buildManager.getTurretToBuild() == null)
            return;

        if (turret != null)
        {
            Debug.Log("There is an already turret. First Sell it to build new one");
            return;
        }

        //Build turrent
        GameObject turretToBuild = buildManager.getTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }
}
