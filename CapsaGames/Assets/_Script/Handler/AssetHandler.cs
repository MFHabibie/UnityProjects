using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class AssetHandler : MonoBehaviour
{
    public Sprite[] cardImageDiamond;
    public Sprite[] cardImageClover;
    public Sprite[] cardImageHeart;
    public Sprite[] cardImagePike;
    public Sprite cardCover;
    public Sprite[] avatarExpression;

    public GameObject prefabCard;

    public Sprite GetCardSprite(int index, CardType type)
    {
        index = index - 2;
        Sprite sprite = null;

        if (type == CardType.Diamonds)
        {
            sprite = cardImageDiamond[index];
        }
        else if(type == CardType.Clovers)
        {
            sprite = cardImageClover[index];
        }
        else if (type == CardType.Hearts)
        {
            sprite = cardImageHeart[index];
        }
        else if (type == CardType.Pike)
        {
            sprite = cardImagePike[index];
        }

        return sprite;
    }

    public Sprite AvatarSprite(int indexExpression)
    {
        return avatarExpression[indexExpression];
    }
}
