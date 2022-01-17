using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enum
{
    public enum CardType
    {
        Diamonds,
        Clovers,
        Hearts,
        Pike
    }

    public enum CardSet
    {
        Error,
        HighNumber,
        Pair,
        TwoPair,
        ThreeOfKind,
        Straight,
        Flush,
        FullHouse,
        FourOfKind,
        StraightFlush,
        RoyalStraightFlush,
    }

    public enum CardSetup
    {
        FirstLine,
        SecondLine,
        ThirdLine
    }
}
