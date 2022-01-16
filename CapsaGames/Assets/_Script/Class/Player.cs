using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class Player
{
    public string nickName;
    public Cards cardsOnHand;
    public Transform playerSeat;
    public Transform playerCardPlace;

    public string[] keyForCards;

    public Player(string nickName, Transform playerSeat, Transform playerCardPlace)
    {
        this.nickName = nickName;
        this.playerSeat = playerSeat;
        this.playerCardPlace = playerCardPlace;
    }

    public List<Card> GetCards()
    {
        return cardsOnHand.cards;
    }
}
