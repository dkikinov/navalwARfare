using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour {
    public GameObject xAttack;
    public GameObject yAttack;
    public GameObject zAttack;
    public CreateGrid grid;
    public GameObject attackButton;
    public VisibleGrid visiblegrid;
    public TextMeshProUGUI output;
    public CursorControl cursor;
    public GameObject restartbutton;



    char attackType;
    int playerHitCount = 0;
    int opponentHitCount = 0;
    bool keepPlaying;
    bool canPress;
    //Concept is to select an attack type.. Line it how you want and fire.


	// Use this for initialization
	void Start () {
        restartbutton.SetActive(false);
        attackType = ' ' ;
        xAttack.SetActive(false);
        yAttack.SetActive(false);
        zAttack.SetActive(false);
        attackButton.SetActive(false);
        keepPlaying = true;
        canPress = true;
    }

	
    public void PrepareAttack()
    {
        canPress = true;
        attackButton.SetActive(false);
        xAttack.SetActive(true);
        yAttack.SetActive(true);
        zAttack.SetActive(true);
        cursor.setZero();
        visiblegrid.Alternate();
        visiblegrid.changeView();
        if (visiblegrid.playerTurn)
        {
            output.text = "Player 1's Turn!";
        }
        else
        {
            output.text = "Player 2's Turn!";
        }
    }

    public void xAttackPressed()
    {
        grid.setAnimate('x');
        attackType = 'x';
        xAttack.SetActive(false);
        yAttack.SetActive(false);
        zAttack.SetActive(false);
        attackButton.SetActive(true);
    }
    public void yAttackPressed()
    {
        grid.setAnimate('y');
        attackType = 'y';
        xAttack.SetActive(false);
        yAttack.SetActive(false);
        zAttack.SetActive(false);
        attackButton.SetActive(true);
    }
    public void zAttackPressed()
    {
        grid.setAnimate('z');
        attackType = 'z';
        xAttack.SetActive(false);
        yAttack.SetActive(false);
        zAttack.SetActive(false);
        attackButton.SetActive(true);
    }
    public void Fire()
    {
        if (canPress)
        {
            attackButton.SetActive(false);
            canPress = false;
            if (visiblegrid.playerTurn)
            {

                switch (attackType)
                {
                    case 'x':
                        for (int i = 0; i <= 6; i++)
                        {
                            if (grid.checkOpponentGrid(i, grid.getypos(), grid.getzpos()) == 2)
                            {
                                continue;
                            }
                            else if (grid.checkOpponentGrid(i, grid.getypos(), grid.getzpos()) == -1)
                            {
                                grid.updateOpponentGrid(i, grid.getypos(), grid.getzpos(), 0);
                                grid.GetCube(i, grid.getypos(), grid.getzpos()).GetComponent<Renderer>().material.color = Color.blue;
                                output.text = "MISS!";

                            }
                            else if (grid.checkOpponentGrid(i, grid.getypos(), grid.getzpos()) >= 1)
                            {
                                grid.updateOpponentGrid(i, grid.getypos(), grid.getzpos(), 2);
                                grid.GetCube(i, grid.getypos(), grid.getzpos()).GetComponent<Renderer>().material.color = Color.red;

                                output.text = "HIT!";

                                playerHitCount++;
                               if ((playerHitCount == 12) || (opponentHitCount == 12))
                                {
                                    endGame();
                                }
                                break;
                            }
                        }
                        break;
                    case 'y':
                        for (int i = 0; i <= 6; i++)
                        {
                            if (grid.checkOpponentGrid(grid.getxpos(), i, grid.getzpos()) == 2)
                            {
                                continue;
                            }
                            else if (grid.checkOpponentGrid(grid.getxpos(), i, grid.getzpos()) == -1)
                            {
                                grid.updateOpponentGrid(grid.getxpos(), i, grid.getzpos(), 0);
                                grid.GetCube(grid.getxpos(), i, grid.getzpos()).GetComponent<Renderer>().material.color = Color.blue;
                                output.text = "MISS!";

                            }
                            else if (grid.checkOpponentGrid(grid.getxpos(), i, grid.getzpos()) >= 1)
                            {
                                grid.updateOpponentGrid(grid.getxpos(), i, grid.getzpos(), 2);
                                grid.GetCube(grid.getxpos(), i, grid.getzpos()).GetComponent<Renderer>().material.color = Color.red;
                                playerHitCount++;
                                output.text = "HIT!";
                                if ((playerHitCount == 12) || (opponentHitCount == 12))
                                {
                                    endGame();
                                }
                                break;
                            }
                        }
                        break;
                    case 'z':
                        for (int i = 0; i <= 6; i++)
                        {
                            if (grid.checkOpponentGrid(grid.getxpos(), grid.getypos(), i) == 2)
                            {
                                continue;
                            }
                            else if (grid.checkOpponentGrid(grid.getxpos(), grid.getypos(), i) == -1)
                            {
                                grid.updateOpponentGrid(grid.getxpos(), grid.getypos(), i, 0);
                                grid.GetCube(grid.getxpos(), grid.getypos(), i).GetComponent<Renderer>().material.color = Color.blue;
                                output.text = "MISS!";
                                
                            }
                            else if (grid.checkOpponentGrid(grid.getxpos(), i, grid.getzpos()) >= 1)
                            {
                                grid.updateOpponentGrid(grid.getxpos(), grid.getypos(), i, 2);
                                grid.GetCube(grid.getxpos(), grid.getypos(), i).GetComponent<Renderer>().material.color = Color.red;
                                playerHitCount++;
                                output.text = "HIT!";

                                if ((playerHitCount == 12))
                                {
                                    endGame();
                                }

                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (attackType)
                {
                    case 'x':
                        for (int i = 0; i <= 6; i++)
                        {
                            if (grid.checkPlayerGrid(i, grid.getypos(), grid.getzpos()) == 2)
                            {
                                continue;
                            }
                            else if (grid.checkPlayerGrid(i, grid.getypos(), grid.getzpos()) == -1)
                            {
                                grid.updatePlayerGrid(i, grid.getypos(), grid.getzpos(), 0);
                                grid.GetCube(i, grid.getypos(), grid.getzpos()).GetComponent<Renderer>().material.color = Color.blue;
                                output.text = "MISS!";
                            }
                            else if (grid.checkPlayerGrid(i, grid.getypos(), grid.getzpos()) >= 1)
                            {
                                grid.updatePlayerGrid(i, grid.getypos(), grid.getzpos(), 2);
                                grid.GetCube(i, grid.getypos(), grid.getzpos()).GetComponent<Renderer>().material.color = Color.red;
                                opponentHitCount++;
                                output.text = "HIT!";


                                if ((opponentHitCount == 12))
                                {
                                    endGame();
                                }
                                break;
                            }
                        }
                        break;
                    case 'y':
                        for (int i = 0; i <= 6; i++)
                        {
                            if (grid.checkPlayerGrid(grid.getxpos(), i, grid.getzpos()) == 2)
                            {
                                continue;
                            }
                            else if (grid.checkPlayerGrid(grid.getxpos(), i, grid.getzpos()) == -1)
                            {
                                grid.updatePlayerGrid(grid.getxpos(), i, grid.getzpos(), 0);
                                grid.GetCube(grid.getxpos(), i, grid.getzpos()).GetComponent<Renderer>().material.color = Color.blue;
                                output.text = "MISS!";
                            }
                            else if (grid.checkPlayerGrid(grid.getxpos(), i, grid.getzpos()) >= 1)
                            {
                                grid.updatePlayerGrid(grid.getxpos(), i, grid.getzpos(), 2);
                                grid.GetCube(grid.getxpos(), i, grid.getzpos()).GetComponent<Renderer>().material.color = Color.red;
                                opponentHitCount++;
                                output.text = "HIT!";
                                if ((opponentHitCount == 12))
                                {
                                    endGame();
                                }
                                break;
                            }
                        }
                        break;
                    case 'z':
                        for (int i = 0; i <= 6; i++)
                        {
                            if (grid.checkPlayerGrid(grid.getxpos(), grid.getypos(), i) == 2)
                            {
                                continue;
                            }
                            else if (grid.checkPlayerGrid(grid.getxpos(), grid.getypos(), i) == -1)
                            {
                                grid.updatePlayerGrid(grid.getxpos(), grid.getypos(), i, 0);
                                grid.GetCube(grid.getxpos(), grid.getypos(), i).GetComponent<Renderer>().material.color = Color.blue;
                                output.text = "MISS!";
                            }
                            else if (grid.checkPlayerGrid(grid.getxpos(), i, grid.getzpos()) >= 1)
                            {
                                grid.updatePlayerGrid(grid.getxpos(), grid.getypos(), i, 2);
                                grid.GetCube(grid.getxpos(), grid.getypos(), i).GetComponent<Renderer>().material.color = Color.red;
                                playerHitCount++;
                                output.text = "HIT!";
                                if ((playerHitCount == 12))
                                {
                                    endGame();
                                }

                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            if (keepPlaying)
            {
                Debug.Log("player hit count: " + playerHitCount);
                Debug.Log("opponent hit count: " + opponentHitCount);
                Invoke("PrepareAttack", 3f);
            }
        }
    }

    public void endGame() 
    {
        keepPlaying = false;
        output.text = "GAME OVER";
        if (playerHitCount == 12) {
            output.text += "! Player Wins!";
        }
        else {
            output.text += "! Opponent Wins!";
        }
        restartbutton.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
