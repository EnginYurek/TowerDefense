using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;
    private Node target;

    public Text sellAmount;

    public void setTarget(Node node)
    {
        target = node;

        transform.position = target.getBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.getSellAmount().ToString();
        ui.SetActive(true);
    }

    public void hide()
    {
        ui.SetActive(false);
    }

    public void upgrade()
    {
        Debug.Log("Upgrade ButtonPressed");
        target.upgradeTurret();
        BuildManager.instance.deselectNode();
    }

    public void sell()
    {
        target.sellTurret();
        BuildManager.instance.deselectNode();
    }
}
