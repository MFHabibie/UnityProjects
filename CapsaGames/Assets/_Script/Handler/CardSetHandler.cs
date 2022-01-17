using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class CardSetHandler : MonoBehaviour
{
    public Dictionary<string, int> setForThree;
    public Dictionary<string, List<string>> setForFour;
    public Dictionary<string, List<string>> setForSpecial;

    public KeyValuePair<Card, CardSet> CheckFirstLineCard(List<Card> firstLine)
    {
        int sameCard = 0;
        Card highCard = null;
        Card pairCard = null;
        Dictionary<int, int> countCard = new Dictionary<int, int>();
        KeyValuePair<Card, CardSet> cardSet = new KeyValuePair<Card, CardSet>();

        foreach (Card card in firstLine)
        {
            if (!countCard.ContainsKey(card.cardNumber))
            {
                countCard.Add(card.cardNumber, 1);
            }
            else
            {
                int counting = 0;
                countCard.TryGetValue(card.cardNumber, out counting);
                countCard.Remove(card.cardNumber);
                counting++;
                countCard.Add(card.cardNumber, counting);

                if (counting == 2 || counting == 3)
                {
                    pairCard = card;
                    sameCard = counting;
                }
            }

            if (highCard == null)
                highCard = card;
            else
            {
                if (highCard.cardNumber < card.cardNumber)
                    highCard = card;
            }
        }

        if (sameCard == 2)
            cardSet = new KeyValuePair<Card, CardSet>(pairCard, CardSet.Pair);
        else if (sameCard == 3)
            cardSet = new KeyValuePair<Card, CardSet>(pairCard, CardSet.ThreeOfKind);
        else
            cardSet = new KeyValuePair<Card, CardSet>(highCard, CardSet.HighNumber);

        return cardSet;
    }

    public KeyValuePair<Card, CardSet> CheckSecondLineCard(List<Card> nextLine)
    {
        int savedNumb = 0;
        int countStraight = 0;
        List<int> straightNumb = new List<int>();

        int countTwoPair = 0;
        int countFlush = 0;
        Card highCard = null;
        Card twoKindCard = null;
        Card twoPairCard = null;
        Card threeKindCard = null;
        Card fourKindCard = null;
        Card flushCard = null;
        CardSet temporarySet = CardSet.Error;
        Dictionary<int, int> countCard = new Dictionary<int, int>();
        KeyValuePair<Card, CardSet> cardSet = new KeyValuePair<Card, CardSet>();

        foreach (Card card in nextLine)
        {
            straightNumb.Add(card.cardNumber);

            if (!countCard.ContainsKey(card.cardNumber))
            {
                countCard.Add(card.cardNumber, 1);
            }
            else
            {
                int counting = 0;
                countCard.TryGetValue(card.cardNumber, out counting);
                countCard.Remove(card.cardNumber);
                counting++;
                countCard.Add(card.cardNumber, counting);

                if (counting == 2)
                {
                    twoKindCard = card;

                    if (countTwoPair == 0)
                    {
                        twoPairCard = card;
                        countTwoPair++;
                    }
                    else
                    {
                        if (twoPairCard.cardNumber > card.cardNumber)
                            twoPairCard = card;

                        countTwoPair++;
                    }
                }
                else if (counting == 3)
                {
                    twoKindCard = null;
                    threeKindCard = card;
                }
                else if (counting == 4)
                {
                    threeKindCard = null;
                    fourKindCard = card;
                    temporarySet = CardSet.FourOfKind;
                }
            }

            if (highCard == null)
                highCard = card;
            else
            {
                if (highCard.cardNumber < card.cardNumber)
                    highCard = card;
            }

            if (countFlush == 0)
            {
                flushCard = card;
                countFlush++;
            }
            else
            {
                if (flushCard.cardType == card.cardType)
                    countFlush++;
            }
        }

        straightNumb.Sort();
        savedNumb = straightNumb[0];

        foreach (int numb in straightNumb)
        {
            if (savedNumb + 1 == numb)
            {
                savedNumb = numb;
                countStraight++;
            }
        }

        if (countFlush == 5)
        {
            if (countStraight == 4)
                temporarySet = CardSet.StraightFlush;
            else
                temporarySet = CardSet.Flush;
        }
        else
        {
            foreach (KeyValuePair<int, int> entry in countCard)
            {
                if (entry.Value == 2)
                {
                    if (threeKindCard == null)
                    {
                        temporarySet = CardSet.Pair;
                        if (temporarySet == CardSet.Pair && countTwoPair == 2)
                            temporarySet = CardSet.TwoPair;
                    }
                    else
                        temporarySet = CardSet.FullHouse;
                }
                else if (entry.Value == 3 && temporarySet == CardSet.Error)
                {
                    temporarySet = CardSet.ThreeOfKind;
                }
            }
        }

        if (temporarySet == CardSet.Flush || temporarySet == CardSet.StraightFlush)
            cardSet = new KeyValuePair<Card, CardSet>(highCard, temporarySet);
        else if (temporarySet == CardSet.ThreeOfKind || temporarySet == CardSet.FullHouse)
            cardSet = new KeyValuePair<Card, CardSet>(threeKindCard, temporarySet);
        else if (temporarySet == CardSet.Pair)
            cardSet = new KeyValuePair<Card, CardSet>(twoKindCard, temporarySet);
        else if (temporarySet == CardSet.TwoPair)
            cardSet = new KeyValuePair<Card, CardSet>(twoPairCard, temporarySet);
        else if (temporarySet == CardSet.FourOfKind)
            cardSet = new KeyValuePair<Card, CardSet>(fourKindCard, CardSet.FourOfKind);
        else
            cardSet = new KeyValuePair<Card, CardSet>(highCard, CardSet.HighNumber);

        return cardSet;
    }
}
