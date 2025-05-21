using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerDestroyHelper : MonoBehaviour
{
    public Player player;
    public void KillPlayer()
    {
        player.DestroyMe();
    }
}
