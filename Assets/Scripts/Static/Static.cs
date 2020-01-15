using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Static
{
    public static Character[] SaveCharacters = new Character[6];//キャラクターをセーブしておける数
    public static int CountOfDeck = 26;//デッキに必要なカードの数
    public static int CountOfHand = 6;//手札の数とりあえず最大6で
    public static int CountOfSelectCard = 3;//選択しておけるカード最大とりま3
}
