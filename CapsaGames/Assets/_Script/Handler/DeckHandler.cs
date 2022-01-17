using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class DeckHandler : MonoBehaviour
{
    public Dictionary<string, GameObject> deck;
    private List<string> cardKeysUsable;

    private AssetHandler assetHandler;


    private void Start()
    {
        assetHandler = GameManager.Instance.assetHandler;

        SetupCard();
    }

    void SetupCard()
    {
        deck = new Dictionary<string, GameObject>();

        cardKeysUsable = new List<string>();

        int cardTypeLength = System.Enum.GetNames(typeof(CardType)).Length;

        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < cardTypeLength; j++)
            {

                string key = (i + 2).ToString() + ((CardType)j).ToString();

                GameObject card = Instantiate(assetHandler.prefabCard, new Vector3(0f, 0f, 0f), Quaternion.identity);
                card.GetComponent<CardObject>().SetupCard(key, i + 2, j);
                card.SetActive(false);

                deck.Add(key, card);
                cardKeysUsable.Add(key);
            }
        }
    }

    public Card TakeRandomCard(Vector2 cardPosition, Quaternion cardRotation)
    {
        string key = cardKeysUsable[Random.Range(0, cardKeysUsable.Count)];

        cardKeysUsable.Remove(key);
        GameObject cardToGive = deck[key];
        cardToGive.SetActive(true);
        cardToGive.transform.position = cardPosition;
        cardToGive.transform.rotation = cardRotation;

        return cardToGive.GetComponent<CardObject>().card;
    }

    public CardObject GetCardFromKey(string key)
    {
        return deck[key].GetComponent<CardObject>();
    }

    public void ReturnCard(string key)
    {
        GameObject objToReturn = deck[key];
        objToReturn.GetComponent<CardObject>().CloseCard();
        objToReturn.SetActive(false);
        cardKeysUsable.Add(key);
    }
}
