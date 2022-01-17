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
    public int winEachLine;

    KeyValuePair<Card, int> scoreFirstLine;
    KeyValuePair<Card, int> scoreSecondLine;
    KeyValuePair<Card, int> scoreThirdLine;

    void Start()
    {
        AssetHandler asset = GameManager.Instance.assetHandler;
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
    
    public void SetupScore(KeyValuePair<Card, int> firstLine, KeyValuePair<Card, int> secondLine, KeyValuePair<Card, int> thirdLine)
    {
        scoreFirstLine = firstLine;
        scoreSecondLine = secondLine;
        scoreThirdLine = thirdLine;
    }

    public KeyValuePair<Card, int> GetFirstLineScore()
    {
        return scoreFirstLine;
    }
    public KeyValuePair<Card, int> GetSecondLineScore()
    {
        return scoreSecondLine;
    }
    public KeyValuePair<Card, int> GetThirdLineScore()
    {
        return scoreThirdLine;
    }
}
