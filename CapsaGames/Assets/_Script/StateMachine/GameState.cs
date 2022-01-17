using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    public List<Card> cards;

    private DeckHandler deckHandler;
    private GameObject[] allPlayer;

    private int firstLineScore;
    private int secondLineScore;
    private int thirdLineScore;
    private int highestScore;

    private GameObject winner;

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

        deckHandler = GameManager.Instance.deckHandler;
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

        yield return new WaitForSeconds(1.5f);
        SetupCardHandler.instance.StartSetup();
    }

    public void CalculateResult()
    {
        for (int i = 0; i < allPlayer.Length; i++)
        {
            if (allPlayer[i].GetComponent<AIPlayer>())
            {
                allPlayer[i].GetComponent<AIPlayer>().SetupScore();
            }
        }

        for (int i = 0; i < allPlayer.Length; i++)
        {
            if (allPlayer[i].GetComponent<LocalPlayer>())
            {
                if (firstLineScore < allPlayer[i].GetComponent<LocalPlayer>().GetFirstLineScore().Value)
                {
                    firstLineScore = allPlayer[i].GetComponent<LocalPlayer>().GetFirstLineScore().Value;
                    allPlayer[i].GetComponent<LocalPlayer>().winEachLine++;
                }

                if (secondLineScore < allPlayer[i].GetComponent<LocalPlayer>().GetSecondLineScore().Value)
                {
                    secondLineScore = allPlayer[i].GetComponent<LocalPlayer>().GetSecondLineScore().Value;
                    allPlayer[i].GetComponent<LocalPlayer>().winEachLine++;
                }

                if (thirdLineScore < allPlayer[i].GetComponent<LocalPlayer>().GetThirdLineScore().Value)
                {
                    thirdLineScore = allPlayer[i].GetComponent<LocalPlayer>().GetThirdLineScore().Value;
                    allPlayer[i].GetComponent<LocalPlayer>().winEachLine++;
                }
            }
            else
            {
                if (firstLineScore < allPlayer[i].GetComponent<AIPlayer>().GetFirstLineScore().Value)
                {
                    firstLineScore = allPlayer[i].GetComponent<AIPlayer>().GetFirstLineScore().Value;
                    allPlayer[i].GetComponent<AIPlayer>().winEachLine++;
                }

                if (secondLineScore < allPlayer[i].GetComponent<AIPlayer>().GetSecondLineScore().Value)
                {
                    secondLineScore = allPlayer[i].GetComponent<AIPlayer>().GetSecondLineScore().Value;
                    allPlayer[i].GetComponent<AIPlayer>().winEachLine++;
                }

                if (thirdLineScore < allPlayer[i].GetComponent<AIPlayer>().GetThirdLineScore().Value)
                {
                    thirdLineScore = allPlayer[i].GetComponent<AIPlayer>().GetThirdLineScore().Value;
                    allPlayer[i].GetComponent<AIPlayer>().winEachLine++;
                }
            }
        }

        for (int i = 0; i < allPlayer.Length; i++)
        {
            if (allPlayer[i].GetComponent<LocalPlayer>())
            {
                if (highestScore < allPlayer[i].GetComponent<LocalPlayer>().winEachLine)
                {
                    highestScore = allPlayer[i].GetComponent<LocalPlayer>().winEachLine;
                    winner = allPlayer[i];
                }
            }
            else
            {
                if (highestScore < allPlayer[i].GetComponent<AIPlayer>().winEachLine)
                {
                    highestScore = allPlayer[i].GetComponent<AIPlayer>().winEachLine;
                    winner = allPlayer[i];
                }
            }
        }

        for (int i = 0; i < allPlayer.Length; i++)
        {
            if (winner == allPlayer[i])
            {
                if (winner.GetComponent<LocalPlayer>())
                {
                    winner.GetComponent<LocalPlayer>().Happy();
                }
                else
                {
                    winner.GetComponent<AIPlayer>().Happy();
                }
            }
            else
            {
                if (allPlayer[i].GetComponent<LocalPlayer>())
                {
                    allPlayer[i].GetComponent<LocalPlayer>().Angry();
                }
                else
                {
                    allPlayer[i].GetComponent<AIPlayer>().Angry();
                }
            }
        }

        


        StartCoroutine("ReturningCard");
    }

    IEnumerator ReturningCard()
    {
        yield return new WaitForSeconds(3f);

        for (int i = 0; i < allPlayer.Length; i++)
        {
            if (allPlayer[i].GetComponent<LocalPlayer>())
            {
                List<Card> cards = allPlayer[i].GetComponent<LocalPlayer>().player.GetCards();
                for (int ind = 0; ind < cards.Count; ind++)
                {
                    deckHandler.ReturnCard(cards[i].keyForCard);
                }

                allPlayer[i].GetComponent<LocalPlayer>().Default();
            }
            else
            {
                List<Card> cards = allPlayer[i].GetComponent<AIPlayer>().player.GetCards();
                for (int ind = 0; ind < cards.Count; ind++)
                {
                    deckHandler.ReturnCard(cards[i].keyForCard);
                }

                allPlayer[i].GetComponent<AIPlayer>().Default();
            }
        }
    }
}
