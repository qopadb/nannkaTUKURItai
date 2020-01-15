using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Iunit
{
    public Profession profession;//職業
    public SkillCard[] Deck = new SkillCard[Static.CountOfDeck];//Deck
    //基礎ステータス7種
    public int MAG;
    public int STR;
    public int DEX;
    public int AGI;
    public int INF;
    public int VIT;
    public int MND;
    public int PIE;
    //装備による加算値(基礎ステ7種)
    public int MAGequ;
    public int STRequ;
    public int DEXequ;
    public int AGIequ;
    public int INFequ;
    public int VITequ;
    public int MNDequ;
    public int PIEequ;
    //Lvupでの加算値(基礎ステ7種)
    public int MAGlv;
    public int STRlv;
    public int DEXlv;
    public int AGIlv;
    public int INFlv;
    public int VITlv;
    public int MNDlv;
    public int PIElv;
    //計算後の基礎ステ7種
    public int MAGtow;
    public int STRtow;
    public int DEXtow;
    public int AGItow;
    public int INFtow;
    public int VITtow;
    public int MNDtow;
    public int PIEtow;
    //実数値 13個now
    private int HP;
    private int currentHP;
    private int Cost;
    private int Speed;//行動ゲージの溜まる速さ
    private int Power;//物理ダメージ
    private int MagicPower;//魔法ダメージ
    private int Armor;//物理防御
    private int MagicResist;//魔法防御
    private int Resist;//デバフ耐性
    private int EvadeRate;//回避率
    private int AccuracyRate;//命中率
    private int Critical;//クリティカル
    private int DebuffPower;//デバフのかけやすさ
    private int Resilience;//回復力
    public Character()
    {
        for(int i = 0; i < Deck.Length; i++)
        {
            Deck[i] = new SkillCard();
        }
    }
    public int unitHP
    {
        get { return HP; }
        set { HP = value; }
    }
    public int unitCurrentHP
    {
        get { return currentHP; }
        set { currentHP = value; }
    }
    public int unitCost
    {
        get { return Cost; }
        set { Cost = value; }
    }
    public int unitSpeed
    {
        get { return Speed; }
        set { Speed = value; }
    }
    public int unitPower
    {
        get { return Power; }
        set { Power = value; }
    }
    public int unitMagicPower
    {
        get { return MagicPower; }
        set { MagicPower = value; }
    }
    public int unitArmor
    {
        get { return Armor; }
        set { Armor = value; }
    }
    public int unitMagicResist
    {
        get { return MagicResist; }
        set { MagicResist = value; }
    }
    public int unitResist
    {
        get { return Resist; }
        set { Resist = value; }
    }
    public int unitEvadeRate
    {
        get { return EvadeRate; }
        set { EvadeRate = value; }
    }
    public int unitAccuracyRate
    {
        get { return AccuracyRate; }
        set { AccuracyRate = value; }
    }
    public int unitCritical
    {
        get { return Critical; }
        set { Critical = value; }
    }
    public int unitDebuffPower
    {
        get { return DebuffPower; }
        set { DebuffPower = value; }
    }
    public int unitResilience
    {
        get { return Resilience; }
        set { Resilience = value; }
    }
}