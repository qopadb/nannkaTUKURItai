using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Iunit
{
    private Profession profession;
    //基礎ステータス7種
    public int MAG;
    public int STR;
    public int DEX;
    public int AGI;
    public int INF;
    public int VIT;
    public int MND;
    //補正値ステータス 範囲は3～18
    public int SIZ;//身長     +STR-AGI
    public int INT;//賢さ     +INF-MND
    public int SEN;//センス   +DEX-INF
    public int STA;//スタミナ +VIT-AGI
    public int MUS;//筋量     +STR-MAG
    public int INS;//狂気     +MAG-MND
    public int SOF;//柔軟性   +DEX-VIT 
    //装備による加算値(基礎ステ7種)
    public int MAGequ;
    public int STRequ;
    public int DEXequ;
    public int AGIequ;
    public int INFequ;
    public int VITequ;
    public int MNDequ;
    //Lvupでの加算値(基礎ステ7種)
    public int MAGlv;
    public int STRlv;
    public int DEXlv;
    public int AGIlv;
    public int INFlv;
    public int VITlv;
    public int MNDlv;
    //計算後の基礎ステ7種
    public int MAGtow;
    public int STRtow;
    public int DEXtow;
    public int AGItow;
    public int INFtow;
    public int VITtow;
    public int MNDtow;
    //実数値 13個now
    private int HP;
    private int MP;
    public int currentHP;
    public int currentMP;
    private int Speed;//行動ゲージの溜まる速さ
    private int Power;//物理ダメージ
    private int MagicPower;//魔法ダメージ
    private int Armor;//物理防御
    private int MagicResist;//魔法防御
    private int Resist;//デバフ耐性
    private int EvadeRate;//回避率
    private int AccuracyRate;//命中率
    private int Critical;//クリティカル
    private int MoveSpeed;//移動速度
    private int DebuffPower;//デバフのかけやすさ
}
