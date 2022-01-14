using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class CardObject : MonoBehaviour
{
    public Card card;

    Sprite cardNumberSprite;
    SpriteRenderer spriteRender;

    public void SetupCard(string key, int cardNumb, int type)
    {
        card = new Card(key, cardNumb, (CardType)type);

        cardNumberSprite = AssetHandler.instance.GetCardSprite(cardNumb, card.cardType);
        spriteRender = GetComponent<SpriteRenderer>();
        CloseCard();
    }

    public void OpenCard()
    {
        spriteRender.sprite = cardNumberSprite;
    }

    public void CloseCard()
    {
        spriteRender.sprite = AssetHandler.instance.cardCover;
    }
}
