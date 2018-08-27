
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {


    public Color hoverColor;

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

        rend.material.color = hoverColor;
    }


    private void OnMouseExit()
    {
        rend.material.color = initialColor;
    }

    private void OnMouseDown()
    {
        if (!buildManager.canBuild)
            return;

        if (turret != null)
        {
            Debug.Log("There is an already turret. First Sell it to build new one");
            return;
        }

        buildManager.buildTurretOn(this);

    }

    public Vector3 getBuildPosition()
    {
       return transform.position + positionOffset;
    }
}
