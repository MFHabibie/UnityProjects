using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : MonoBehaviour
{
    public Player player;

    public PlayerState playerState;
    public Avatar avatarPlayer;
    public Sprite avatarImage;
    public Transform cardPlace;

    void Start()
    {
        AssetHandler asset = AssetHandler.instance;
        avatarImage = GetComponent<SpriteRenderer>().sprite;

        player = new Player("LocalPlayer", transform, cardPlace);
        playerState = new PlayerState(player, avatarPlayer);
        avatarPlayer = new Avatar(asset.avatarExpression[0], asset.avatarExpression[1], asset.avatarExpression[2]);
    }

    public void Default()
    {
        avatarImage = avatarPlayer.Default();
    }

    public void Happy()
    {
        avatarImage = avatarPlayer.Happy();
    }

    public void Angry()
    {
        avatarImage = avatarPlayer.Angry();
    }
}
