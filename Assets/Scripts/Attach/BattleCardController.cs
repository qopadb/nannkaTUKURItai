using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCardController : MonoBehaviour
{
    [SerializeField] private GameObject CardSprite;//Cardのprefab
    [SerializeField] private GameObject SelectCardSprite;//SelectCardのprefab
    [SerializeField] private GameObject EmptyCardCount;//CardCount
    [SerializeField] private GameObject ShadowSprite;//Shadow
    private SkillCard[] hand = new SkillCard[Static.CountOfHand];//handの配列
    private SkillCard[] select = new SkillCard[Static.CountOfSelectCard];//SelectCardの配列
    private GameObject[] handShadow = new GameObject[Static.CountOfHand];//handに射す影…
    private GameObject[] selectShadow = new GameObject[Static.CountOfSelectCard];//selectに射す影…
    private List<SkillCard> cardInDeck = new List<SkillCard>();//山札
    private List<SkillCard> cardInTrash = new List<SkillCard>();//捨札
    private Text DeckCount;//そのまま
    private Text TrashCount;//そのまま
    private int SelectHandCard = 0;//いまどのカード選んでる？
    private bool FightNow = false;
    //ちょっとした数値
    private Vector3 NomalCardScale = new Vector3(0.24f, 0.24f, 1);//CardSpriteの標準のscale 縮小版はxとyがこれの2/3
    private Vector3 FirstSelectCardPosition = new Vector3(-7.8f, -0.8f, 21);//SelectCardの大きいやつのposition
    private Vector3 NomalSelectScale = new Vector3(0.1752f, 0.2424f, 1);//SelectCardの標準のscale 縮小版はxとyがこれの2/3
    private void MakeBattleField(Character character)
    {
        FightNow = true;
        cardInDeck.Clear();
        cardInTrash.Clear();
        cardInDeck.AddRange(character.Deck);
        EmptyCardCount.SetActive(true);
        for(int i = 0; i < Static.CountOfSelectCard; i++)
        {
            if(i == 0)
            {
                GameObject select = Instantiate(SelectCardSprite, FirstSelectCardPosition, Quaternion.identity, this.gameObject.transform);
                select.transform.localScale = NomalSelectScale;
            }
            else
            {
                GameObject select = Instantiate(SelectCardSprite, SelectCardPosition(i), Quaternion.identity, this.gameObject.transform);
                select.transform.localScale = new Vector3(NomalSelectScale.x / 3 * 2, NomalSelectScale.y / 3 * 2, 1);
            }
        }
        for(int i = 0; i < Static.CountOfHand; i++)
        {
            Draw(character, i);
        }
        MakeShadow();
    }
    private void DeleteBattleField()
    {
        FightNow = false;
        cardInDeck.Clear();
        cardInTrash.Clear();
        EmptyCardCount.SetActive(false);
        foreach(Transform child in this.gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    private void Draw(Character character, int handNumber)//俺のターン！ドロー！
    {
        if(cardInDeck.Count == 0)
        {
            cardInDeck.AddRange(cardInTrash);
            cardInTrash.Clear();
        }
        int num = Random.Range(0, cardInDeck.Count);
        hand[handNumber] = cardInDeck[num];
        cardInDeck.RemoveAt(num);
        GameObject card = Instantiate(CardSprite, HandCardPosition(handNumber), Quaternion.identity, this.gameObject.transform);
        card.transform.localScale = NomalCardScale;
        hand[handNumber].card = card;
    }
    private void MakeShadow()//影作るよ
    {
        Vector3 shadowScale = new Vector3(0.156f, 0.39f, 1);
        for (int i = 0; i < Static.CountOfHand; i++)//handのshadow
        {
            GameObject shadow = Instantiate(ShadowSprite, HandCardPosition(i) + new Vector3(0, 0, -1), Quaternion.identity, this.gameObject.transform);
            shadow.transform.localScale = shadowScale;
            handShadow[i] = shadow;
        }
        for (int i = 0; i < Static.CountOfSelectCard; i++)//selectのshadow
        {
            if(i != 0)
            {
                GameObject shadow = Instantiate(ShadowSprite, SelectCardPosition(i) + new Vector3(0, 0, -1), Quaternion.identity, this.gameObject.transform);
                shadow.transform.localScale = new Vector3(shadowScale.x / 3 * 2, shadowScale.y / 3 * 2, 1);
                selectShadow[i] = shadow;
            }
        }
    }
    private void SetActiveShadow()//影の管理するよ！
    {
        foreach (GameObject gameObject in handShadow)//選んだカードをスポットライト！(実は選んでないカードに影を射してます)
        {
            gameObject.SetActive(true);
        }
        handShadow[SelectHandCard].SetActive(false);
        for (int i = 0; i < Static.CountOfSelectCard; i++)//選択予備？にカードがあると影が射します　よっカードの影男！
        {
            if (i != 0)
            {
                if (select[i] == null)
                {
                    selectShadow[i].SetActive(false);
                }
                else
                {
                    selectShadow[i].SetActive(true);
                }
            }
        }
    }
    private Vector3 HandCardPosition(int num)//何番目か渡したらHandCardのpositionが返ってくるメソッド
    {
        Vector3 pos = new Vector3(-7.8f, -3.6f, 21);
        pos.x += num * 2;
        return pos;
    }
    private Vector3 SelectCardPosition(int num)
    {
        Vector3 pos = new Vector3(-7.5f, -1.25f, 21);
        pos.x += num * 1.5f;
        return pos;
    }
    private void Awake()
    {
        DeckCount = EmptyCardCount.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>();
        TrashCount = EmptyCardCount.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>();
    }
    private void Update()
    {
        if (FightNow)
        {
            DeckCount.text = cardInDeck.Count.ToString();
            TrashCount.text = cardInTrash.Count.ToString();
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(SelectHandCard > 0)
                {
                    SelectHandCard--;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (SelectHandCard < Static.CountOfHand - 1)
                {
                    SelectHandCard++;
                }
            }
            SetActiveShadow();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (FightNow)
            {
                DeleteBattleField();
            }
            else
            {
                MakeBattleField(new Character());
            }
        }
    }
}
