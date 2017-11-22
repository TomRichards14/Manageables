using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    public static bool do_not = false; //Stops card flipping process

    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    private Sprite _cardBack; //Back of Card
    private Sprite _cardFace; //Face of card

    private GameObject _manager; //Game Manager object

    void Start()
    {
        _state = 1; //Sets state to 1
        _manager = GameObject.FindGameObjectWithTag("Manager"); //Sets _manager to GameManager object

    }

    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<Match2GameManager>().getCardBack ();
        _cardFace = _manager.GetComponent<Match2GameManager>().getCardFace (_cardValue);

        flipCard(); //Calls flip card function
    }

    public void flipCard()
    {
        if(_state == 0 && !do_not)
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1 && !do_not)
            GetComponent<Image>().sprite = _cardFace;
    }

    public int cardValue
    {
        get { return _cardValue;  }
        set { _cardValue = value; }
    }

    public int state
    {
        get { return _state; }
        set { _state = value; }
    }
    
    public bool initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }

    public void falseCheck()
    {
        StartCoroutine(pause ());
    }
    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if (_state == 0)
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1)
            GetComponent<Image>().sprite = _cardFace;
        do_not = false;
    }
}
