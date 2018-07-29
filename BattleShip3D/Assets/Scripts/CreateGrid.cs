using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour {
    public GameObject invisicube;
    public GameObject[ ,  , ] cubes;
    public int[,,] playerGrid; //-1  = no action, 0 = miss, 1 = ship, 2 = hit
    public int[,,] opponentGrid; //-1  = no action, 0 = miss, 1 = ship, 2 = hit
    public Material water;
    int size;
    bool bigger;
    bool animate;
    bool animateSingle;
    bool animatelineX;
    bool animatelineY;
    bool animatelineZ;
    Vector3 scaleSize;
    int xpos;
    int ypos;
    int zpos;
    // Use this for initialization
    void Start () {
        xpos = 0;
        ypos = 0;
        zpos = 0;
        size = 1;
        bigger = true;
        animate = true;
        animateSingle = true;
        animatelineX = false;
        animatelineY = false;
        animatelineZ = false;
        cubes = new GameObject[7, 7, 7];
        playerGrid = new int[7, 7, 7];
       opponentGrid = new int[7, 7, 7];
        for (int x = -3; x <=3; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                for(int z = -3; z<=3; z++)
                {
                    GameObject temp = Instantiate(invisicube) as GameObject;
                    temp.transform.parent = gameObject.transform;
                    temp.transform.position = new Vector3(x * 0.05f, y * 0.05f, z * 0.05f);
                    cubes[x + 3, y, z + 3] = temp ;
                    playerGrid[x + 3, y, z + 3] = -1;
                    opponentGrid[x + 3, y, z + 3] = -1;
                    if(y < 3)
                    {
                        temp.GetComponent<Renderer>().material = water;
                    }
                }
            }
        }
        scaleSize = cubes[0, 0, 0].transform.localScale;
        setCubeColour();
        //gameObject.transform.position += new Vector3(0f, -0.1f, 1f);
    }
    
    // Update is called once per frame
    void Update() {
        if (animate)
        {
            //Single
            if (animateSingle)
            {
                // Single

                if (bigger)
                {
                    cubes[xpos, ypos, zpos].transform.localScale = cubes[xpos, ypos, zpos].transform.localScale + new Vector3(0.0005f, 0.0005f, 0.0005f);
                    size++;
                }
                if (size >= 50)
                {
                    bigger = false;
                }
                if (!bigger)
                {
                    cubes[xpos, ypos, zpos].transform.localScale = cubes[xpos, ypos, zpos].transform.localScale - new Vector3(0.0005f, 0.0005f, 0.0005f);
                    size--;
                }
                if (size <= 1)
                {
                    bigger = true;
                }
            }
            //Line  in X
            else if (animatelineX)
            {
                if (bigger)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        cubes[i, ypos, zpos].transform.localScale = cubes[i, ypos, zpos].transform.localScale + new Vector3(0.0005f, 0.0005f, 0.0005f);
                    }
                    size++;
                }
                if (size >= 50)
                {
                    bigger = false;
                }
                if (!bigger)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        cubes[i, ypos, zpos].transform.localScale = cubes[i, ypos, zpos].transform.localScale - new Vector3(0.0005f, 0.0005f, 0.0005f);
                    }
                    size--;
                }
                if (size <= 1)
                {
                    bigger = true;
                }
            }
            //Line in Y
            else if (animatelineY)
            {
                if (bigger)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        cubes[xpos, i, zpos].transform.localScale = cubes[xpos, i, zpos].transform.localScale + new Vector3(0.0005f, 0.0005f, 0.0005f);
                    }
                    size++;
                }
                if (size >= 50)
                {
                    bigger = false;
                }
                if (!bigger)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        cubes[xpos, i, zpos].transform.localScale = cubes[xpos,i, zpos].transform.localScale - new Vector3(0.0005f, 0.0005f, 0.0005f);
                    }
                    size--;
                }
                if (size <= 1)
                {
                    bigger = true;
                }
            }
            //Line in Z
            else if (animatelineZ)
            {
                if (bigger)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        cubes[xpos, ypos, i].transform.localScale = cubes[xpos, ypos, i].transform.localScale + new Vector3(0.0005f, 0.0005f, 0.0005f);
                    }
                    size++;
                }
                if (size >= 50)
                {
                    bigger = false;
                }
                if (!bigger)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        cubes[xpos, ypos, i].transform.localScale = cubes[xpos, ypos, i].transform.localScale - new Vector3(0.0005f, 0.0005f, 0.0005f);
                    }
                    size--;
                }
                if (size <= 1)
                {
                    bigger = true;
                }
            }
        }
        else
        {
            size = 1;
        }
    }

    public void setxpos(int num)
    {
        animate = false;
        resetCubeColour();
        resetCubeSize();
        xpos = num;
        setCubeColour();
        animate = true;
    }
    public void setypos(int num)
    {
        animate = false;
        resetCubeSize();
        resetCubeColour();
        ypos = num;
        setCubeColour();
        animate = true;
    }
    public void setzpos(int num)
    {
        animate = false;
        resetCubeSize();
        resetCubeColour();
        zpos = num;
        setCubeColour();
        animate = true;
    }
    public int getxpos()
    {
        return xpos;
    }
    public int getypos()
    {
        return ypos;
    }
    public int getzpos()
    {
        return zpos;
    }
    public void setCubeColour(int x = -1, int y = -1, int z = -1)
    {
        if(x == -1)
        {
            x = xpos;
        }
        if(y == -1)
        {
            y = ypos;
        }
        if(z == -1)
        {
            z = ypos;
        }
        foreach (Transform child in cubes[xpos, ypos, zpos].transform)
        {
            child.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
    public void resetCubeColour(int x = -1, int y = -1, int z = -1)
    {
        if (x == -1)
        {
            x = xpos;
        }
        if (y == -1)
        {
            y = ypos;
        }
        if (z == -1)
        {
            z = ypos;
        }
        foreach (Transform child in cubes[xpos, ypos, zpos].transform)
        {
            child.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
    void resetCubeSize()
    {
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 6; y++)
            {
                for (int z = 0; z < 6; z++)
                {
                    cubes[x,y,z].transform.localScale = scaleSize;
                }
            }
        }
    }
    public void setAnimate(char c)
    {
        animate = false;
        animatelineX = false;
        animatelineY = false;
        animatelineZ = false;
        animateSingle = false;
        switch (c)
        {
            case 'x':
                animatelineX = true;
                break;
            case 'y':
                animatelineY = true;
                break;
            case 'z':
                animatelineZ = true;
                    break;
            default:
                animateSingle = true;
                break;
                
        }
        animate = true;
    }
    public void updatePlayerGrid(int x, int y, int z, int value)
    {
        playerGrid[x, y, z] = value;
    }
    public void updateOpponentGrid(int x, int y, int z, int value)
    {
        opponentGrid[x, y, z] = value;
    }
    public int checkPlayerGrid(int x, int y, int z)
    {
        return playerGrid[x, y, z];
    }
    public int checkOpponentGrid(int x, int y, int z)
    {
        return opponentGrid[x, y, z];
    }
    public GameObject GetCube(int x, int y, int z)
    {
        return cubes[x, y, z];
    }

    public bool flipCoin()
    {
        return Random.value < 0.5f;
    }
    public void recreateGrid()
    {
       foreach(GameObject cube in cubes)
        {
            Destroy(cube);
        }
        cubes = new GameObject[7, 7, 7];
        for (int x = -3; x <= 3; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                for (int z = -3; z <= 3; z++)
                {
                    GameObject temp = Instantiate(invisicube) as GameObject;
                    temp.transform.parent = gameObject.transform;
                    temp.transform.position = new Vector3(x * 0.05f, y * 0.05f, z * 0.05f);
                    cubes[x + 3, y, z + 3] = temp;
                    if (y < 3)
                    {
                        temp.GetComponent<Renderer>().material = water;
                    }
                }
            }
        }
        scaleSize = cubes[0, 0, 0].transform.localScale;
        setCubeColour();
       // gameObject.transform.position += new Vector3(0f, -0.1f, 1f);
    }
}
