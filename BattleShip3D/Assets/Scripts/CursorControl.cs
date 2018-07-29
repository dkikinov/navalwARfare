using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorControl : MonoBehaviour {
    public TextMeshProUGUI zText;
    public TextMeshProUGUI yText;
    public TextMeshProUGUI xText;
    public CreateGrid grid;
    public int zValue;
    public int xValue;
    public int yValue;
	// Use this for initialization
	void Start () {
        xValue = grid.getxpos();
        yValue = grid.getypos();
        zValue = grid.getzpos();
	}
	
	// Update is called once per frame
	void Update () {
        xText.text = xValue.ToString();
        yText.text = yValue.ToString();
        zText.text = zValue.ToString();
    }

   public void increaseZ()
    {
        Debug.Log("Z Pressed");
        if (zValue < 6)
        {
            zValue++;
        }
        grid.setzpos(zValue);
    }
    public void increaseY()
    {
        if (yValue < 6)
        {
            yValue++;
        }
        grid.setypos(yValue);
    }
    public void increaseX()
    {
        if (xValue < 6)
        {
            xValue++;
        }
        grid.setxpos(xValue);
    }
    public void decreaseZ()
    {
        if(zValue > 0)
        {
            zValue--;
        }
        grid.setzpos(zValue);
    }
    public void decreaseY()
    {
        if (yValue > 0)
        {
            yValue--;
        }
        grid.setypos(yValue);
    }
    public void decreaseX()
    {
        if (xValue > 0)
        {
            xValue--;
        }
        grid.setxpos(xValue);
    }
    public void setZero()
    {
        xValue = 0;
        yValue = 0;
        zValue = 0;
        grid.setxpos(0);
        grid.setypos(0);
        grid.setzpos(0);
    }
}
