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
        Card[] dummyCard = new Card[11];
        player.keyForCards = new string[11];

        for (int i = 0; i < 11; i++)
        {
            while (dummyCard[i] == null)
            {
                dummyCard[i] = GameState.instance.deckHandler.TakeRandomCard(player.playerCardPlace.position, player.playerCardPlace.rotation);
            }
            player.keyForCards[i] = dummyCard[i].keyForCard;
        }

        player.cardsOnHand = new Cards(dummyCard);
        return true;
    }
}
