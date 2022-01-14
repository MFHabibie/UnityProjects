using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    public Player player;

    public PlayerState playerState;
    public Avatar avatarPlayer;
    public Sprite avatarImage;
    public Transform cardPlace;

    void Start()
    {
        player = new Player("AI-Player", transform, cardPlace);
        playerState = new PlayerState(player, avatarPlayer);
    }
}
