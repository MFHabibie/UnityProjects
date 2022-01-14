using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class DeckHandler : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> deck;

    AssetHandler assetHandler;

    List<string> cardKeysUsable;

    private void Start()
    {
        assetHandler = AssetHandler.instance;

        SetupCard();
    }

    void SetupCard()
    {
        deck = new Dictionary<string, Queue<GameObject>>();

        cardKeysUsable = new List<string>();

        int cardTypeLength = System.Enum.GetNames(typeof(CardType)).Length;

        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < cardTypeLength; j++)
            {
                Queue<GameObject> deckCard = new Queue<GameObject>();

                string key = (i + 2).ToString() + ((CardType)j).ToString();

                GameObject card = Instantiate(assetHandler.prefabCard, new Vector3(0f, 0f, 0f), Quaternion.identity);
                card.GetComponent<CardObject>().SetupCard(key, i + 2, j);
                card.SetActive(false);
                deckCard.Enqueue(card);

                deck.Add(key, deckCard);
                cardKeysUsable.Add(key);
            }
        }
    }

    public Card TakeRandomCard(Vector2 cardPosition, Quaternion cardRotation)
    {
        string key = cardKeysUsable[Random.Range(0, cardKeysUsable.Count)];

        cardKeysUsable.Remove(key);
        GameObject cardToGive = deck[key].Dequeue();
        cardToGive.SetActive(true);
        cardToGive.transform.position = cardPosition;
        cardToGive.transform.rotation = cardRotation;

        return cardToGive.GetComponent<CardObject>().card;
    }

    public void ReturnCard(string key)
    {
        GameObject objToReturn = deck[key].Peek();
        objToReturn.SetActive(false);
        deck[key].Enqueue(objToReturn);
        cardKeysUsable.Add(key);
    }
}
