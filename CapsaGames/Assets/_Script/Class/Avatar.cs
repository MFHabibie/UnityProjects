using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar
{
    public Sprite defaultFace;
    public Sprite happyFace;
    public Sprite angryFace;

    public Avatar(Sprite defaultF, Sprite happyF, Sprite angryF)
    {
        defaultFace = defaultF;
        happyFace = happyF;
        angryFace = angryF;
    }

    public Sprite Default()
    {
        return defaultFace;
    }

    public Sprite Happy()
    {
        return happyFace;
    }

    public Sprite Angry()
    {
        return angryFace;
    }
}
