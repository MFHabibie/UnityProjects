using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class Cards
{
    public int rowOneSum = 3;
    public int rowTwoThreeSum = 4;
    public List<Card> cards;
    public List<CardSet> cardSets;

    public Cards(List<Card> deck)
    {
        cards = deck;
    }

    int ValueRowOne()
    {
        return 0;
    }

    int ValueRowTwo()
    {
        return 0;
    }

    int ValueRowThree()
    {
        return 0;
    }
}
