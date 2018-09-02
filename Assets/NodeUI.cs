using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour {

    public GameObject ui;

    private Node target;

    public void setTarget(Node node)
    {
        target = node;

        transform.position = target.getBuildPosition();
        ui.SetActive(true);
    }

    public void hide()
    {
        ui.SetActive(false);
    }
}
