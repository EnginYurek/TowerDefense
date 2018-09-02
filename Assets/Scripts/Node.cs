
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {


    public Color hoverColor;
    public Color notEnoughMoneyColour;
    private Renderer rend;
    private Color initialColor;

    [Header("Optional")]
    public GameObject turret;

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

        if (!buildManager.canBuild)
            return;

        if (buildManager.hasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColour;
        }
    }


    private void OnMouseExit()
    {
        rend.material.color = initialColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.selectNode(this);
            return;
        }

        if (!buildManager.canBuild)
            return;

        buildManager.buildTurretOn(this);

    }

    public Vector3 getBuildPosition()
    {
       return transform.position + positionOffset;
    }
}
