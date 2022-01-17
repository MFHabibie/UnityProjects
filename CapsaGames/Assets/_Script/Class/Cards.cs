using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class Cards
{
    public List<Card> cards;
    public List<CardSet> cardSets;

    public Cards(List<Card> deck)
    {
        cards = deck;
    }

    public int ValueRowOne()
    {
        return 0;
    }

    public int ValueRowTwo()
    {
        return 0;
    }

    public int ValueRowThree()
    {
        return 0;
    }
}
