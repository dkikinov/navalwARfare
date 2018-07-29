using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisibleGrid : MonoBehaviour {
    public GameObject[] playerunits;
    public GameObject[] opponentunits;
    public CreateGrid grid;
    int index;
    public bool playerTurn;
    public GameObject image;
    public GameObject button;
    public TextMeshProUGUI text;
	// Use this for initialization
	void Start () {
        index = 0;
        playerunits = new GameObject[6];
        opponentunits = new GameObject[6];
        playerTurn = true;
	}
	
    public void AddUnitPlayer(GameObject go)
    {
        playerunits[index] = go;
        index++;
    }
    public void AddUnitOpponent(GameObject go)
    {
            if (index == 6)
        {
            index = 0;
        }
        opponentunits[index] = go;
        index++;
    }
    public void hidePlayerUnits()
    {
        foreach (GameObject go in playerunits)
        {
            go.SetActive(false);
        }
    }
    public void hideEnemyUnits()
    {
        foreach (GameObject go in opponentunits)
        {
            go.SetActive(false);
        }
    }
    public void showPlayerUnits()
    {
        foreach (GameObject go in playerunits)
        {
            go.SetActive(true);
        }
    }
    public void showOpponentUnits()
    {
        foreach (GameObject go in opponentunits)
        {
            go.SetActive(true);
        }
    }


    public void changeView()
    {
        grid.recreateGrid();
        playerTurn = !playerTurn;
        if (playerTurn)
        {
            
           for(int x = 0; x <= 6; x++)
            {
                for(int y = 0; y <= 6; y++)
                {
                    for(int z = 0; z<=6; z++)
                    {
                        if(grid.checkOpponentGrid(x,y,z) == 0)
                        {
                            grid.cubes[x, y, z].GetComponent<Renderer>().material.color = Color.blue;
                        }
                        else if(grid.checkOpponentGrid(x,y,z) == 2)
                        {
                            grid.cubes[x, y, z].GetComponent<Renderer>().material.color = Color.red;
                        }
                    }
                }
            }
        }
        else
        {
            for (int x = 0; x <= 6; x++)
            {
                for (int y = 0; y <=6; y++)
                {
                    for (int z = 0; z <= 6; z++)
                    {
                        if (grid.checkPlayerGrid(x, y, z) == 0)
                        {
                            grid.cubes[x, y, z].GetComponent<Renderer>().material.color = Color.blue;
                        }
                        else if (grid.checkPlayerGrid(x, y, z) == 2)
                        {
                            grid.cubes[x, y, z].GetComponent<Renderer>().material.color = Color.red;
                        }
                    }
                }
            }
        }
    }
	public void Alternate()
    {
        image.SetActive(true);
        button.SetActive(true);
        if (playerTurn)
        {
            text.text = "Pass it on to Player 2!";
        }
        else
        {
            text.text = "Pass it on to Player 1!";
        }
    }
}
