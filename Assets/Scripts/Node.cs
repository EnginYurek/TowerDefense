
using UnityEngine;

public class Node : MonoBehaviour {


    public Color hoverColor;

    private Renderer rend;
    private Color initialColor;

    private GameObject turret;

    public Vector3 positionOffset;

    private void Start()
    {
        rend = GetComponent<Renderer>();

        initialColor = rend.material.color;
    }
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }


    private void OnMouseExit()
    {
        rend.material.color = initialColor;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Hit te deck!!");
            return;
        }

        //Build turrent
        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }
}
