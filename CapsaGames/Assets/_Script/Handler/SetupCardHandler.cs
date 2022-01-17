using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupCardHandler : MonoBehaviour
{
    public static SetupCardHandler instance;

    public GameObject screenForSetup;
    public GameObject placeForOpenCard;

    public List<Card> firstLineSet;
    public List<Card> secondLineSet;
    public List<Card> thirdLineSet;

    private DeckHandler deckHandler;
    private CardSetHandler cardSetHandler;
    private UIHandler uiHandler;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        deckHandler = GameManager.Instance.deckHandler;
        uiHandler = GameManager.Instance.uiHandler;
        cardSetHandler = GameManager.Instance.cardSetHandler;

        firstLineSet = new List<Card>();
        secondLineSet = new List<Card>();
        thirdLineSet = new List<Card>();

        screenForSetup.SetActive(false);
        uiHandler.canvasSetup.gameObject.SetActive(false);
        uiHandler.completeBtn().onClick.AddListener(SetupComplete);
    }

    public void StartSetup()
    {
        LocalPlayer player = FindObjectOfType<LocalPlayer>();
        List<CardObject> playerCards = new List<CardObject>();
        Vector3 tempPosition = placeForOpenCard.transform.position;

        screenForSetup.SetActive(true);
        uiHandler.canvasSetup.gameObject.SetActive(true);

        foreach (Card card in player.player.cardsOnHand.cards)
        {
            playerCards.Add(deckHandler.GetCardFromKey(card.keyForCard));
        }

        foreach (CardObject obj in playerCards)
        {
            tempPosition = new Vector3(tempPosition.x + 1f, tempPosition.y, tempPosition.z - 0.1f);

            obj.isOnSetup = true;
            obj.gameObject.transform.position = tempPosition;
            obj.gameObject.transform.localScale = obj.gameObject.transform.localScale * 2.0f;
            obj.OpenCard();
        }
    }

    public void CheckFirstLine()
    {
        uiHandler.SetFirstText(cardSetHandler.CheckFirstLineCard(firstLineSet).Value.ToString());
    }
    public void CheckSecondLine()
    {
        uiHandler.SetSecondText(cardSetHandler.CheckSecondLineCard(secondLineSet).Value.ToString());
    }
    public void CheckThirdLine()
    {
        uiHandler.SetThirdText(cardSetHandler.CheckSecondLineCard(thirdLineSet).Value.ToString());
    }

    void SetupComplete()
    {
        LocalPlayer player = FindObjectOfType<LocalPlayer>();
        Card firstLineKey = cardSetHandler.CheckFirstLineCard(firstLineSet).Key;
        int firstLineValue = (int)cardSetHandler.CheckFirstLineCard(firstLineSet).Value;

        Card secondLineKey = cardSetHandler.CheckSecondLineCard(secondLineSet).Key;
        int secondLineValue = (int)cardSetHandler.CheckSecondLineCard(secondLineSet).Value;

        Card thirdLineKey = cardSetHandler.CheckSecondLineCard(thirdLineSet).Key;
        int thirdLineValue = (int)cardSetHandler.CheckSecondLineCard(thirdLineSet).Value;

        var scoreFirstLineBySet = new KeyValuePair<Card, int>(firstLineKey, firstLineValue);
        var scoreSecondLineBySet = new KeyValuePair<Card, int>(secondLineKey, secondLineValue);
        var scoreThirdLineBySet = new KeyValuePair<Card, int>(thirdLineKey, thirdLineValue);

        player.SetupScore(scoreFirstLineBySet, scoreSecondLineBySet, scoreThirdLineBySet);

        GameState.instance.CalculateResult();

        screenForSetup.SetActive(false);
        uiHandler.canvasSetup.gameObject.SetActive(false);
    }
}
