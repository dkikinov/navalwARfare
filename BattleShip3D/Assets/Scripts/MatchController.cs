using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MatchController : MonoBehaviour
{
    public bool IsReady { get { return localPlayer != null && remotePlayer != null; } }
    public PlayerController localPlayer;
    public PlayerController remotePlayer;
    public CreateGrid grid;
    public AttackScript attack;
    public VisibleGrid visGrid;
    public void Initialize()
    {
        while (remotePlayer == null)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
            {
                if (go != localPlayer)
                {
                    remotePlayer = go.GetComponent<PlayerController>();
                }
            }
        }
        PlayerController temp = localPlayer;
        localPlayer = remotePlayer;
        remotePlayer = temp;
        grid.playerGrid = localPlayer.field;
        grid.opponentGrid = remotePlayer.field;
    }



}