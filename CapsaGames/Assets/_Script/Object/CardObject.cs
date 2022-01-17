using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Enum;

public class CardObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Card card;
    public bool isOnSetup;

    Sprite cardNumberSprite;
    SpriteRenderer spriteRender;

    private AssetHandler assetHandler;
    private SetupCardHandler setupCard;
    private Vector3 positionOnOpen;
    private Vector3 startPosition;
    private Vector3 startScale;
    private Collider2D objCollider;
    private Collider2D locationCollider;
    private bool isOnClick;
    private bool isAtLocation;

    public void SetupCard(string key, int cardNumb, int type)
    {
        assetHandler = GameManager.Instance.assetHandler; 
        setupCard = GameManager.Instance.setupCardHandler;

        card = new Card(key, cardNumb, (CardType)type);

        cardNumberSprite = GameManager.Instance.assetHandler.GetCardSprite(cardNumb, card.cardType);
        spriteRender = GetComponent<SpriteRenderer>();
        objCollider = GetComponent<BoxCollider2D>();
        startPosition = transform.position;
        startScale = transform.localScale;
        CloseCard();
    }

    public void OpenCard()
    {
        spriteRender.sprite = cardNumberSprite;
        if(isOnSetup)
        {
            positionOnOpen = transform.position;
        }
    }

    public void CloseCard()
    {
        spriteRender.sprite = assetHandler.cardCover;
        transform.position = startPosition;
        transform.localScale = startScale;
        isOnSetup = false;
    }

    private void Update()
    {
        if (isOnSetup)
        {
            if (isOnClick)
            {
                Vector2 newLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(newLocation.x, newLocation.y, transform.position.z);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerEnter == this.gameObject)
        {
            isOnClick = true;

            if (locationCollider != null)
            {
                CardLocation cardLoc = locationCollider.GetComponent<CardLocation>();
                cardLoc.isAlreadyFilled = false;
                RemoveOnSet(cardLoc);
                locationCollider = null;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isOnClick = false;
        CardLocation cardLoc = null;

        if (locationCollider != null)
        {
            cardLoc = locationCollider.GetComponent<CardLocation>();

            if (Vector2.Distance(objCollider.transform.position, locationCollider.transform.position) < 1f)
            {
                Vector3 tempPos = new Vector3(locationCollider.transform.position.x, locationCollider.transform.position.y, transform.position.z);
                transform.position = tempPos;
                cardLoc.isAlreadyFilled = true;
                AddToSet(cardLoc);
            }
            else
            {
                transform.position = positionOnOpen;
                RemoveOnSet(cardLoc);
                locationCollider = null;
            }

        }
        else
        {
            transform.position = positionOnOpen;
        }
    }

    void AddToSet(CardLocation loc)
    {
        if (loc.setupLine == CardSetup.FirstLine)
        {
            setupCard.firstLineSet.Add(card);
            setupCard.CheckFirstLine();
        }
        else if (loc.setupLine == CardSetup.SecondLine)
        {
            setupCard.secondLineSet.Add(card);
            setupCard.CheckSecondLine();
        }
        else
        {
            setupCard.thirdLineSet.Add(card);
            setupCard.CheckThirdLine();
        }
    }

    void RemoveOnSet(CardLocation loc)
    {
        if (loc.setupLine == CardSetup.FirstLine && setupCard.firstLineSet.Count != 0)
        {
            setupCard.firstLineSet.Remove(card);
            setupCard.CheckFirstLine();
        }
        else if (loc.setupLine == CardSetup.SecondLine && setupCard.secondLineSet.Count != 0)
        {
            setupCard.secondLineSet.Remove(card);
            setupCard.CheckSecondLine();
        }
        else if (loc.setupLine == CardSetup.ThirdLine && setupCard.thirdLineSet.Count != 0)
        {
            setupCard.thirdLineSet.Remove(card);
            setupCard.CheckThirdLine();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CardLocation>() && !collision.GetComponent<CardLocation>().isAlreadyFilled)
        {
            locationCollider = collision;
        }
    }
}
