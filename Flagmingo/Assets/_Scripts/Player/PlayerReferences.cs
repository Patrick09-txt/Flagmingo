using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerReferences : MonoBehaviour
{
    public PlayerInputManager InputManager;
    public Camera Camera;
    public Player Player;

    private void Awake()
    {
        InputManager = GameObject.FindGameObjectWithTag("PlayerManager")?.GetComponent<PlayerInputManager>();
        if (InputManager != null)
        {
            this.Player.PlayerNumber = (PlayerNumber)InputManager.playerCount - 1;
            Debug.Log("Set player number to " + this.Player.PlayerNumber + ", based on there being " + InputManager.playerCount + " players in the game.");
        }
    }
}
