using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour
{
    public int[,,] field;
    public CreateGrid grid;
    public MatchController mc;
    public override void OnStartClient()
    {
        base.OnStartClient();
        grid = GameObject.Find("Grid").GetComponent<CreateGrid>();
        field = grid.playerGrid;
        mc = GameObject.Find("MatchController").GetComponent<MatchController>();
        mc.localPlayer = this;
        mc.Initialize();
    }
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
    }
    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
    }
    
}