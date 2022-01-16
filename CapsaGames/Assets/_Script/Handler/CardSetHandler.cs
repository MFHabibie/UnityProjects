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


    private void Start()
    {
        
    }

    public KeyValuePair<Card, CardSet> CheckFirstLineCard(List<Card> firstLine)
    {
        int sameCard = 0;
        Card highCard = new Card();
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
                countCard.Add(card.cardNumber, counting++);

                if (counting == 2)
                {
                    cardSet = new KeyValuePair<Card, CardSet>(card, CardSet.Pair);
                }
                else if (counting == 3)
                {
                    cardSet = new KeyValuePair<Card, CardSet>(card, CardSet.Error);
                }
            }

            if (highCard.cardNumber < card.cardNumber)
                highCard = card;
        }

        foreach (KeyValuePair<int, int> entry in countCard)
        {
            if (entry.Value == 2)
            {
                sameCard = entry.Value;
                break;
            }
        }

        if (sameCard == 0)
            cardSet = new KeyValuePair<Card, CardSet>(highCard, CardSet.HighNumber);


        return cardSet;
    }

    public KeyValuePair<Card, CardSet> CheckSecondLineCard(List<Card> nextLine)
    {
        int savedNumb = 0;
        int countStraight = 0;
        List<int> straightNumb = new List<int>();

        int countFlush = 0;
        Card twoKindCard = null;
        Card twoPairCard = null;
        Card threeKindCard = null;
        Card flushCard = null;
        Card highCard = null;
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
                countCard.Add(card.cardNumber, counting++);

                if (counting == 2)
                {
                    twoKindCard = card;

                    if (twoKindCard != card)
                    {

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
                    temporarySet = CardSet.FourOfKind;
                    cardSet = new KeyValuePair<Card, CardSet>(card, CardSet.FourOfKind);
                }
            }

            if (highCard.cardNumber < card.cardNumber)
                highCard = card;

            if(countFlush == 0)
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
            {
                cardSet = new KeyValuePair<Card, CardSet>(highCard, CardSet.StraightFlush);
            }
            else
            {
                cardSet = new KeyValuePair<Card, CardSet>(highCard, CardSet.Flush);
            }
        }
        else
        {
            foreach (KeyValuePair<int, int> entry in countCard)
            {
                if (entry.Value == 2 && threeKindCard == null)
                {
                    temporarySet = CardSet.Pair;
                }
                else if (entry.Value == 2 && temporarySet == CardSet.Pair)
                {
                    temporarySet = CardSet.TwoPair;
                }
                else if (entry.Value == 2 && threeKindCard != null)
                {
                    temporarySet = CardSet.FullHouse;
                }
                else if (entry.Value == 3 && temporarySet == CardSet.Error)
                {
                    temporarySet = CardSet.ThreeOfKind;
                }
            }

            if (temporarySet == CardSet.Error)
            {
                cardSet = new KeyValuePair<Card, CardSet>(highCard, CardSet.HighNumber);
            }
            else if (temporarySet == CardSet.ThreeOfKind || temporarySet == CardSet.FullHouse)
            {
                cardSet = new KeyValuePair<Card, CardSet>(threeKindCard, temporarySet);
            }
            else if (temporarySet == CardSet.Pair)
            {
                cardSet = new KeyValuePair<Card, CardSet>(twoKindCard, temporarySet);
            }
            else if (temporarySet == CardSet.TwoPair)
            {
                cardSet = new KeyValuePair<Card, CardSet>(twoPairCard, temporarySet);
            }
        }

        return cardSet;
    }
}
