using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class PlayerState
{
    Player player;
    Avatar avatar;

    public PlayerState(Player player, Avatar avatar)
    {
        this.player = player;
        this.avatar = avatar;
    }

    void Win()
    {
        
    }

    void Lose()
    {
        
    }

    public bool ReceiveCard()
    {
        Debug.Log("Draw!");
        List<Card> dummyCard = new List<Card>();
        player.keyForCards = new string[13];

        for (int i = 0; i < player.keyForCards.Length; i++)
        {
            dummyCard.Add(GameManager.Instance.deckHandler.TakeRandomCard(player.playerCardPlace.position, player.playerCardPlace.rotation));
            player.keyForCards[i] = dummyCard[i].keyForCard;
        }

        player.cardsOnHand = new Cards(dummyCard);
        return true;
    }
}
