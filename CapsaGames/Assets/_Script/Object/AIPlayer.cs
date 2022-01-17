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

    public void SetupScore()
    {
        CardSetHandler cardSet = GameManager.Instance.cardSetHandler;

        List<Card> firstLineCard = new List<Card>();
        List<Card> secondLineCard = new List<Card>();
        List<Card> thirdLineCard = new List<Card>();

        for (int i = 0; i < player.cardsOnHand.cards.Count; i++)
        {
            if (i < 3)
                firstLineCard.Add(player.cardsOnHand.cards[i]);
            else if (i > 2 && i <= 7)
                secondLineCard.Add(player.cardsOnHand.cards[i]);
            else
                thirdLineCard.Add(player.cardsOnHand.cards[i]);
        }

        var firstLine = new KeyValuePair<Card, int>(cardSet.CheckFirstLineCard(firstLineCard).Key, (int)cardSet.CheckFirstLineCard(firstLineCard).Value); 
        var secondLine = new KeyValuePair<Card, int>(cardSet.CheckSecondLineCard(secondLineCard).Key, (int)cardSet.CheckSecondLineCard(secondLineCard).Value);
        var thirdLine = new KeyValuePair<Card, int>(cardSet.CheckSecondLineCard(thirdLineCard).Key, (int)cardSet.CheckSecondLineCard(thirdLineCard).Value);

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
