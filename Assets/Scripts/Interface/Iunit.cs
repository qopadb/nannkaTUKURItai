using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iunit
{
    int unitHP { get; set; }
    int unitMP { get; set; }
    int unitCurrentHP { get; set; }
    int unitCurrentMP { get; set; }
    int unitSpeed { get; set; }//行動ゲージの溜まる速さ
    int unitPower { get; set; }//物理ダメージ
    int unitMagicPower { get; set; }//魔法ダメージ
    int unitArmor { get; set; }//物理防御
    int unitMagicResist { get; set; }//魔法防御
    int unitResist { get; set; }//デバフ耐性
    int unitEvadeRate { get; set; }//回避率
    int unitAccuracyRate { get; set; }//命中率
    int unitCritical { get; set; }//クリティカル
    int unitDebuffPower { get; set; }//デバフのかけやすさ
}
