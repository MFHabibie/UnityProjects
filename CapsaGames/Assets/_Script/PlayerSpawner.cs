using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject localPlayer;
    public GameObject aiPlayer;

    public Transform seat1;
    public Transform seat2;
    public Transform seat3;
    public Transform seat4;

    public Transform cardSeat1;
    public Transform cardSeat2;
    public Transform cardSeat3;
    public Transform cardSeat4;

    void Start()
    {
        GameObject dummyObj;

        dummyObj = Instantiate(localPlayer);
        dummyObj.transform.position = seat1.position;
        dummyObj.GetComponent<LocalPlayer>().cardPlace = cardSeat1;

        dummyObj = Instantiate(aiPlayer);
        dummyObj.transform.position = seat2.position;
        dummyObj.GetComponent<AIPlayer>().cardPlace = cardSeat2;

        dummyObj = Instantiate(aiPlayer);
        dummyObj.transform.position = seat3.position;
        dummyObj.GetComponent<AIPlayer>().cardPlace = cardSeat3;

        dummyObj = Instantiate(aiPlayer);
        dummyObj.transform.position = seat4.position;
        dummyObj.GetComponent<AIPlayer>().cardPlace = cardSeat4;

    }
}
