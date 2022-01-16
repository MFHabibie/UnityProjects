using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    public DeckHandler deckHandler;

    public List<Card> cards;

    GameObject[] allPlayer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Invoke("Setup", 1f);

        Invoke("DrawCard", 3f);
    }

    void Setup()
    {
        GameObject[] playerObject = GameObject.FindGameObjectsWithTag("Player");
        allPlayer = new GameObject[playerObject.Length];
        for (int i = 0; i < playerObject.Length; i++)
        {
            allPlayer[i] = playerObject[i];
        }

        deckHandler = FindObjectOfType<DeckHandler>();
    }

    void DrawCard()
    {
        StartCoroutine("DrawEachPlayer");
    }

    IEnumerator DrawEachPlayer()
    {
        for (int i = 0; i < allPlayer.Length; i++)
        {
            if (allPlayer[i].GetComponent<LocalPlayer>())
            {
                while (!allPlayer[i].GetComponent<LocalPlayer>().playerState.ReceiveCard())
                    yield return null;
            }
            else
            {
                while (!allPlayer[i].GetComponent<AIPlayer>().playerState.ReceiveCard())
                    yield return null;
            }
        }
    }

    //function for take back card from player hand
    void ResetCard()
    {

    }

    void CalculateResult()
    {
        StartCoroutine("ReturningCard");
    }

    IEnumerator ReturningCard()
    {


        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < allPlayer.Length; i++)
        {
            if (allPlayer[i].GetComponent<LocalPlayer>())
            {
                List<Card> cards = allPlayer[i].GetComponent<LocalPlayer>().player.GetCards();
                for (int ind = 0; ind < cards.Count; ind++)
                {
                    deckHandler.ReturnCard(cards[i].keyForCard);
                }
            }
            else
            {
                List<Card> cards = allPlayer[i].GetComponent<AIPlayer>().player.GetCards();
                for (int ind = 0; ind < cards.Count; ind++)
                {
                    deckHandler.ReturnCard(cards[i].keyForCard);
                }
            }
        }
    }
}
