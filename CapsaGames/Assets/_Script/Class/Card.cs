using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class Card
{
    public string keyForCard;
    public int cardNumber;
    public CardType cardType;

    public Card(string key, int number, CardType type)
    {
        keyForCard = key;
        cardNumber = number;
        cardType = type;
    }
}

