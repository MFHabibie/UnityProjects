using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AssetHandler assetHandler;
    public UIHandler uiHandler;
    public DeckHandler deckHandler;
    public CardSetHandler cardSetHandler;
    public SetupCardHandler setupCardHandler;

    private void Awake()
    {
        Instance = this;
    }
}
