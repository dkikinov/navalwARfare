using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaceShip : MonoBehaviour {
    public GameObject submarine;
    public GameObject plane;
    public GameObject ship;
    public GameObject placeButton;
    public CreateGrid grid;
    public TextMeshProUGUI output;
    public AttackScript attack;
    public VisibleGrid visibleGrid;
    int subcount;
    int planecount;
    int shipcount;
    int x1, x2, y1, y2, z1, z2;
    int placed;
   
	// Use this for initialization
	void Start () {
        subcount = 0;
        planecount = 0;
        shipcount = 0;
        x1 = -1;
        x2 =- 1;
        y1 = -1;
        y2 = -1;
        z1 = -1;
        z2 = -1;
        placed = 0;
        output.text = "Please select an underwater space for a Submarine: ";
        placeButton.GetComponentInChildren<Text>().text = "Select Space";
	}
    private void Update()
    {
        if (x1 != -1)
        {
            grid.setCubeColour(x1, y1, z1);
        }
        if (x2 != -1)
        {
            grid.setCubeColour(x2, y2, z2);
        }
    }
    public void PlaceWarRig () {
        Debug.Log(visibleGrid.playerTurn);
        if (visibleGrid.playerTurn)
        {
            Debug.Log("Here!");
            if (grid.getypos() < 3 && subcount < 2 && x1 == -1 && grid.checkPlayerGrid(grid.getxpos(), grid.getypos(), grid.getzpos()) == -1)
            {
                Debug.Log("First Sub Space!");
                x1 = grid.getxpos();
                y1 = grid.getypos();
                z1 = grid.getzpos();
                output.text = "Please select an adjacent underwater space for the Submarine:  ";
                placeButton.GetComponentInChildren<Text>().text = "Place Sub";
                Debug.Log("First Sub Space Over!");
            }
            else if (grid.getypos() == y1 && subcount < 2 && x2 == -1 && (grid.getxpos() != x1 || grid.getzpos() != z1)
                && grid.checkPlayerGrid(grid.getxpos(), grid.getypos(), grid.getzpos()) == -1)
            {
                Debug.Log(x1 - grid.getxpos());
                Debug.Log(grid.getzpos() - z1);
                if (((x1 - grid.getxpos()) == 1 || (x1 - grid.getxpos()) == -1) && (grid.getzpos() - z1) == 0)
                {
                    Debug.Log("Second Sub First If");
                    x2 = grid.getxpos();
                    y2 = grid.getypos();
                    z2 = grid.getzpos();
                    GameObject go = Instantiate(submarine) as GameObject;
                    go.transform.position = ((grid.GetCube(x1, y1, z1).transform.position) + (grid.GetCube(x2, y2, z2).transform.position)) / 2f;
                    go.transform.Rotate(new Vector3(0f, 90f, 0));
                    go.transform.parent = grid.gameObject.transform;
                    go.transform.localScale = new Vector3(0.05f, 0.05f, 0.03f) * 25f * 0.15f;
                    visibleGrid.AddUnitPlayer(go);
                    subcount++;
                    grid.updatePlayerGrid(x1, y1, z1, 1);
                    grid.updatePlayerGrid(x2, y2, z2, 1);
                    ResetCount();
                    if (subcount == 1)
                    {
                        output.text = "Please select a new underwater space for the next Submarine:  ";
                    }
                    else
                    {
                        output.text = "Please select a water space for a Warship:  ";
                    }
                    placeButton.GetComponentInChildren<Text>().text = "Select Space";
                }
                else if ((x1 - grid.getxpos()) == 0 && ((z1 - grid.getzpos()) == -1 || (z1 - grid.getzpos()) == 1))
                {
                    Debug.Log("Second Sub Second If");
                    x2 = grid.getxpos();
                    y2 = grid.getypos();
                    z2 = grid.getzpos();
                    GameObject go = Instantiate(submarine) as GameObject;
                    go.transform.position = ((grid.GetCube(x1, y1, z1).transform.position) + (grid.GetCube(x2, y2, z2).transform.position)) / 2f;
                    go.transform.parent = grid.gameObject.transform;
                    go.transform.localScale = new Vector3(0.05f, 0.05f, 0.03f) * 25f * 0.15f;
                    visibleGrid.AddUnitPlayer(go);
                    subcount++;
                    ResetCount();
                    if (subcount == 1)
                    {
                        output.text = "Please select a new underwater space for the next Submarine:  ";
                    }
                    else
                    {
                        output.text = "Please select a water space for a Warship:  ";

                    }
                    placeButton.GetComponentInChildren<Text>().text = "Select Space";
                }
                Debug.Log("Second Sub Space Over!");
            }
            else if (grid.getypos() == 3 && subcount == 2 && shipcount < 2 && x1 == -1 && grid.checkPlayerGrid(grid.getxpos(), grid.getypos(), grid.getzpos()) == -1)
            {
                x1 = grid.getxpos();
                y1 = grid.getypos();
                z1 = grid.getzpos();
                output.text = "Please select an adjacent water space for the Warship:  ";
                placeButton.GetComponentInChildren<Text>().text = "Place Ship";
            }
            else if (grid.getypos() == 3 && subcount == 2 && shipcount < 2 && x2 == -1 && (grid.getxpos() != x1 || grid.getzpos() != z1)
                && grid.checkPlayerGrid(grid.getxpos(), grid.getypos(), grid.getzpos()) == -1)
            {
                if (((x1 - grid.getxpos()) == 1 || (x1 - grid.getxpos()) == -1) && (grid.getzpos() - z1) == 0)
                {
                    x2 = grid.getxpos();
                    y2 = grid.getypos();
                    z2 = grid.getzpos();
                    GameObject go = Instantiate(ship) as GameObject;
                    go.transform.Rotate(new Vector3(0f, 90f, 0));
                    go.transform.position = ((grid.GetCube(x1, y1, z1).transform.position) + (grid.GetCube(x2, y2, z2).transform.position)) / 2f;
                    go.transform.parent = grid.gameObject.transform;
                    go.transform.localScale = new Vector3(0.06f, 0.04f, 0.022f) * 25f * 0.15f;
                    visibleGrid.AddUnitPlayer(go);
                    shipcount++;
                    grid.updatePlayerGrid(x1, y1, z1, 1);
                    grid.updatePlayerGrid(x2, y2, z2, 1);
                    ResetCount();
                    if (shipcount == 1)
                    {
                        output.text = "Please select a new water space for the next Warship:  ";
                    }
                    else
                    {
                        output.text = "Please select an air space for a Plane:  ";
                    }
                    placeButton.GetComponentInChildren<Text>().text = "Select Space";
                }
                else if ((x1 - grid.getxpos()) == 0 && ((z1 - grid.getzpos()) == -1 || (z1 - grid.getzpos()) == 1))
                {
                    x2 = grid.getxpos();
                    y2 = grid.getypos();
                    z2 = grid.getzpos();
                    GameObject go = Instantiate(ship) as GameObject;
                    go.transform.position = ((grid.GetCube(x1, y1, z1).transform.position) + (grid.GetCube(x2, y2, z2).transform.position)) / 2f;
                    go.transform.parent = grid.gameObject.transform;
                    go.transform.localScale = new Vector3(0.06f, 0.04f, 0.022f) * 25 * 0.15f;
                    visibleGrid.AddUnitPlayer(go);
                    shipcount++;
                    ResetCount();
                    if (shipcount == 1)
                    {
                        output.text = "Please select a new water space for the next Warship:  ";
                    }
                    else
                    {
                        output.text = "Please select an air space for a Plane:  ";
                    }
                    placeButton.GetComponentInChildren<Text>().text = "Select Space";
                }
            }
            else if (grid.getypos() > 3 && subcount == 2 && shipcount == 2 && planecount < 2 && x1 == -1)
            {
                x1 = grid.getxpos();
                y1 = grid.getypos();
                z1 = grid.getzpos();
                output.text = "Please select an adjacent air space for the plane:  ";
                placeButton.GetComponentInChildren<Text>().text = "Place Plane";
            }
            else if (grid.getypos() > 3 && subcount == 2 && shipcount == 2 && planecount < 2 && x2 == -1 && (grid.getxpos() != x1 || grid.getzpos() != z1)
                && grid.checkPlayerGrid(grid.getxpos(), grid.getypos(), grid.getzpos()) == -1)
            {
                if (((x1 - grid.getxpos()) == 1 || (x1 - grid.getxpos()) == -1) && (grid.getzpos() - z1) == 0)
                {
                    x2 = grid.getxpos();
                    y2 = grid.getypos();
                    z2 = grid.getzpos();
                    GameObject go = Instantiate(plane) as GameObject;
                    go.transform.position = ((grid.GetCube(x1, y1, z1).transform.position) + (grid.GetCube(x2, y2, z2).transform.position)) / 2f;
                    go.transform.Rotate(new Vector3(0f, 90f, 0));
                    go.transform.parent = grid.gameObject.transform;
                    go.transform.localScale = new Vector3(0.012f, 0.014f, 0.015f) * 25f * 0.15f;
                    visibleGrid.AddUnitPlayer(go);
                    planecount++;
                    grid.updatePlayerGrid(x1, y1, z1, 1);
                    grid.updatePlayerGrid(x2, y2, z2, 1);
                    ResetCount();
                    if (planecount == 1)
                    {
                        output.text = "Please select a new air space for the next Plane:  ";
                    }
                    else
                    {
                        output.text = "All units placed.";
                        placeButton.SetActive(false);
                        Invoke("hideText", 3f);
                    }
                }
                else if ((x1 - grid.getxpos()) == 0 && ((z1 - grid.getzpos()) == -1 || (z1 - grid.getzpos()) == 1))
                {
                    x2 = grid.getxpos();
                    y2 = grid.getypos();
                    z2 = grid.getzpos();
                    GameObject go = Instantiate(plane) as GameObject;
                    go.transform.position = ((grid.GetCube(x1, y1, z1).transform.position) + (grid.GetCube(x2, y2, z2).transform.position)) / 2f;
                    go.transform.parent = grid.gameObject.transform;
                    go.transform.localScale = new Vector3(0.012f, 0.014f, 0.015f) * 25 * 0.15f;
                    visibleGrid.AddUnitPlayer(go);
                    planecount++;
                    grid.updatePlayerGrid(x1, y1, z1, 1);
                    grid.updatePlayerGrid(x2, y2, z2, 1);
                    ResetCount();
                    if (planecount == 1)
                    {
                        output.text = "Please select a new air space for the next Plane:  ";
                    }
                    else
                    {
                        output.text = "All units placed.";
                        placeButton.SetActive(false);
                        Invoke("hideText", 3f);
                    }
                }
            }
        }
        else if (!visibleGrid.playerTurn)
        {
            Debug.Log("In Enemy");
            if (grid.getypos() < 3 && subcount < 2 && x1 == -1 && grid.checkOpponentGrid(grid.getxpos(), grid.getypos(), grid.getzpos()) == -1)
            {
                Debug.Log("First Sub Space!");
                x1 = grid.getxpos();
                y1 = grid.getypos();
                z1 = grid.getzpos();
                output.text = "Please select an adjacent underwater space for the Submarine:  ";
                placeButton.GetComponentInChildren<Text>().text = "Place Sub";
                Debug.Log("First Sub Space Over!");
            }
            else if (grid.getypos() == y1 && subcount < 2 && x2 == -1 && (grid.getxpos() != x1 || grid.getzpos() != z1)
                && grid.checkOpponentGrid(grid.getxpos(), grid.getypos(), grid.getzpos()) == -1)
            {
                Debug.Log(x1 - grid.getxpos());
                Debug.Log(grid.getzpos() - z1);
                if (((x1 - grid.getxpos()) == 1 || (x1 - grid.getxpos()) == -1) && (grid.getzpos() - z1) == 0)
                {
                    Debug.Log("Second Sub First If");
                    x2 = grid.getxpos();
                    y2 = grid.getypos();
                    z2 = grid.getzpos();
                    GameObject go = Instantiate(submarine) as GameObject;
                    go.transform.position = ((grid.GetCube(x1, y1, z1).transform.position) + (grid.GetCube(x2, y2, z2).transform.position)) / 2f;
                    go.transform.Rotate(new Vector3(0f, 90f, 0));
                    go.transform.parent = grid.gameObject.transform;
                    go.transform.localScale = new Vector3(0.05f, 0.05f, 0.03f) * 25f * 0.15f;
                    visibleGrid.AddUnitOpponent(go);
                    subcount++;
                    grid.updateOpponentGrid(x1, y1, z1, 1);
                    grid.updateOpponentGrid(x2, y2, z2, 1);
                    ResetCount();
                    if (subcount == 1)
                    {
                        output.text = "Please select a new underwater space for the next Submarine:  ";
                    }
                    else
                    {
                        output.text = "Please select a water space for a Warship:  ";
                    }
                    placeButton.GetComponentInChildren<Text>().text = "Select Space";
                }
                else if ((x1 - grid.getxpos()) == 0 && ((z1 - grid.getzpos()) == -1 || (z1 - grid.getzpos()) == 1))
                {
                    Debug.Log("Second Sub Second If");
                    x2 = grid.getxpos();
                    y2 = grid.getypos();
                    z2 = grid.getzpos();
                    GameObject go = Instantiate(submarine) as GameObject;
                    go.transform.position = ((grid.GetCube(x1, y1, z1).transform.position) + (grid.GetCube(x2, y2, z2).transform.position)) / 2f;
                    go.transform.parent = grid.gameObject.transform;
                    go.transform.localScale = new Vector3(0.05f, 0.05f, 0.03f) * 25f * 0.15f;
                    visibleGrid.AddUnitOpponent(go);
                    subcount++;
                    ResetCount();
                    if (subcount == 1)
                    {
                        output.text = "Please select a new underwater space for the next Submarine:  ";
                    }
                    else
                    {
                        output.text = "Please select a water space for a Warship:  ";

                    }
                    placeButton.GetComponentInChildren<Text>().text = "Select Space";
                }
                Debug.Log("Second Sub Space Over!");
            }
            else if (grid.getypos() == 3 && subcount == 2 && shipcount < 2 && x1 == -1 && grid.checkOpponentGrid(grid.getxpos(), grid.getypos(), grid.getzpos()) == -1)
            {
                x1 = grid.getxpos();
                y1 = grid.getypos();
                z1 = grid.getzpos();
                output.text = "Please select an adjacent water space for the Warship:  ";
                placeButton.GetComponentInChildren<Text>().text = "Place Ship";
            }
            else if (grid.getypos() == 3 && subcount == 2 && shipcount < 2 && x2 == -1 && (grid.getxpos() != x1 || grid.getzpos() != z1)
                && grid.checkOpponentGrid(grid.getxpos(), grid.getypos(), grid.getzpos()) == -1)
            {
                if (((x1 - grid.getxpos()) == 1 || (x1 - grid.getxpos()) == -1) && (grid.getzpos() - z1) == 0)
                {
                    x2 = grid.getxpos();
                    y2 = grid.getypos();
                    z2 = grid.getzpos();
                    GameObject go = Instantiate(ship) as GameObject;
                    go.transform.Rotate(new Vector3(0f, 90f, 0));
                    go.transform.position = ((grid.GetCube(x1, y1, z1).transform.position) + (grid.GetCube(x2, y2, z2).transform.position)) / 2f;
                    go.transform.parent = grid.gameObject.transform;
                    go.transform.localScale = new Vector3(0.06f, 0.04f, 0.022f) * 25f * 0.15f;
                    visibleGrid.AddUnitOpponent(go);
                    shipcount++;
                    grid.updateOpponentGrid(x1, y1, z1, 1);
                    grid.updateOpponentGrid(x2, y2, z2, 1);
                    ResetCount();
                    if (shipcount == 1)
                    {
                        output.text = "Please select a new water space for the next Warship:  ";
                    }
                    else
                    {
                        output.text = "Please select an air space for a Plane:  ";
                    }
                    placeButton.GetComponentInChildren<Text>().text = "Select Space";
                }
                else if ((x1 - grid.getxpos()) == 0 && ((z1 - grid.getzpos()) == -1 || (z1 - grid.getzpos()) == 1))
                {
                    x2 = grid.getxpos();
                    y2 = grid.getypos();
                    z2 = grid.getzpos();
                    GameObject go = Instantiate(ship) as GameObject;
                    go.transform.position = ((grid.GetCube(x1, y1, z1).transform.position) + (grid.GetCube(x2, y2, z2).transform.position)) / 2f;
                    go.transform.parent = grid.gameObject.transform;
                    go.transform.localScale = new Vector3(0.06f, 0.04f, 0.022f) * 25 * 0.15f;
                    visibleGrid.AddUnitOpponent(go);
                    shipcount++;
                    ResetCount();
                    if (shipcount == 1)
                    {
                        output.text = "Please select a new water space for the next Warship:  ";
                    }
                    else
                    {
                        output.text = "Please select an air space for a Plane:  ";
                    }
                    placeButton.GetComponentInChildren<Text>().text = "Select Space";
                }
            }
            else if (grid.getypos() > 3 && subcount == 2 && shipcount == 2 && planecount < 2 && x1 == -1)
            {
                x1 = grid.getxpos();
                y1 = grid.getypos();
                z1 = grid.getzpos();
                output.text = "Please select an adjacent air space for the plane:  ";
                placeButton.GetComponentInChildren<Text>().text = "Place Plane";
            }
            else if (grid.getypos() > 3 && subcount == 2 && shipcount == 2 && planecount < 2 && x2 == -1 && (grid.getxpos() != x1 || grid.getzpos() != z1)
                && grid.checkOpponentGrid(grid.getxpos(), grid.getypos(), grid.getzpos()) == -1)
            {
                if (((x1 - grid.getxpos()) == 1 || (x1 - grid.getxpos()) == -1) && (grid.getzpos() - z1) == 0)
                {
                    x2 = grid.getxpos();
                    y2 = grid.getypos();
                    z2 = grid.getzpos();
                    GameObject go = Instantiate(plane) as GameObject;
                    go.transform.position = ((grid.GetCube(x1, y1, z1).transform.position) + (grid.GetCube(x2, y2, z2).transform.position)) / 2f;
                    go.transform.Rotate(new Vector3(0f, 90f, 0));
                    go.transform.parent = grid.gameObject.transform;
                    go.transform.localScale = new Vector3(0.012f, 0.014f, 0.015f) * 25f * 0.15f;
                    visibleGrid.AddUnitOpponent(go);
                    planecount++;
                    grid.updateOpponentGrid(x1, y1, z1, 1);
                    grid.updateOpponentGrid(x2, y2, z2, 1);
                    ResetCount();
                    if (planecount == 1)
                    {
                        output.text = "Please select a new air space for the next Plane:  ";
                    }
                    else
                    {
                        output.text = "All units placed.";
                        placeButton.SetActive(false);
                        Invoke("hideText", 3f);
                    }
                }
                else if ((x1 - grid.getxpos()) == 0 && ((z1 - grid.getzpos()) == -1 || (z1 - grid.getzpos()) == 1))
                {
                    x2 = grid.getxpos();
                    y2 = grid.getypos();
                    z2 = grid.getzpos();
                    GameObject go = Instantiate(plane) as GameObject;
                    go.transform.position = ((grid.GetCube(x1, y1, z1).transform.position) + (grid.GetCube(x2, y2, z2).transform.position)) / 2f;
                    go.transform.parent = grid.gameObject.transform;
                    go.transform.localScale = new Vector3(0.012f, 0.014f, 0.015f) * 25 * 0.15f;
                    visibleGrid.AddUnitOpponent(go);
                    planecount++;
                    grid.updateOpponentGrid(x1, y1, z1, 1);
                    grid.updateOpponentGrid(x2, y2, z2, 1);
                    ResetCount();
                    if (planecount == 1)
                    {
                        output.text = "Please select a new air space for the next Plane:  ";
                    }
                    else
                    {
                        output.text = "All units placed.";
                        placeButton.SetActive(false);
                        Invoke("hideText", 3f);
                    }
                }
            }

        }
    }

    void ResetCount()
    {
        grid.resetCubeColour(x1, y1, z1);
        grid.resetCubeColour(x2, y2, z2);
        x1 = -1;
        x2 = -1;
        y1 = -1;
        y2 = -1;
        z1 = -1;
        z2 = -1;
    }

    void hideText()
    {
        placed++;
        if (placed == 1)
        {
            output.text = "Please select an underwater space for a Submarine: ";
            placeButton.GetComponentInChildren<Text>().text = "Select Space";
            subcount = 0;
            planecount = 0;
            shipcount = 0;
            visibleGrid.hidePlayerUnits();
            visibleGrid.Alternate();
            visibleGrid.playerTurn = false;
            placeButton.SetActive(true);
            attack.cursor.setZero();
        }
        else
        {
            visibleGrid.hideEnemyUnits();
            attack.PrepareAttack();
            attack.cursor.setZero();
        }
    }
}
