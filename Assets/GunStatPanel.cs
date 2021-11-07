using Assets.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunStatPanel : MonoBehaviour
{
    public Gun Gun;

    private TMP_Text DmgValue;
    private TMP_Text DmgMod;
    private TMP_Text DmgBase;

    private TMP_Text ForceValue;
    private TMP_Text ForceMod;
    private TMP_Text ForceBase;

    private TMP_Text BPSValue;
    private TMP_Text BPSMod;
    private TMP_Text BPSBase;

    private TMP_Text ClipValue;
    private TMP_Text ClipMod;
    private TMP_Text ClipBase;

    private TMP_Text ReloadValue;
    private TMP_Text ReloadMod;
    private TMP_Text ReloadBase;

    private TMP_Text Accuracy;
    private TMP_Text Stability;
    private TMP_Text Bullets;
    private TMP_Text Ricochet;

    public void Load()
    {
        Transform ValueRow = transform.Find("Rows").Find("ValueRow");
        Transform ModRow = transform.Find("Rows").Find("ModRow");
        Transform BaseRow = transform.Find("Rows").Find("BaseRow");

        DmgValue = ValueRow.Find("Dmg").GetComponent<TMP_Text>();
        DmgMod = ModRow.Find("Dmg").GetComponent<TMP_Text>();
        DmgBase = BaseRow.Find("Dmg").GetComponent<TMP_Text>();

        ForceValue = ValueRow.Find("Force").GetComponent<TMP_Text>();
        ForceMod = ModRow.Find("Force").GetComponent<TMP_Text>();
        ForceBase = BaseRow.Find("Force").GetComponent<TMP_Text>();

        BPSValue = ValueRow.Find("BPS").GetComponent<TMP_Text>();
        BPSMod = ModRow.Find("BPS").GetComponent<TMP_Text>();
        BPSBase = BaseRow.Find("BPS").GetComponent<TMP_Text>();

        ClipValue = ValueRow.Find("Clip").GetComponent<TMP_Text>();
        ClipMod = ModRow.Find("Clip").GetComponent<TMP_Text>();
        ClipBase = BaseRow.Find("Clip").GetComponent<TMP_Text>();

        ReloadValue = ValueRow.Find("Reload").GetComponent<TMP_Text>();
        ReloadMod = ModRow.Find("Reload").GetComponent<TMP_Text>();
        ReloadBase = BaseRow.Find("Reload").GetComponent<TMP_Text>();

        Accuracy = ModRow.Find("Accuracy").GetComponent<TMP_Text>();
        Stability = ModRow.Find("Stability").GetComponent<TMP_Text>();
        Bullets = ValueRow.Find("Bullets").GetComponent<TMP_Text>();
        Ricochet = ValueRow.Find("Ricochet").GetComponent<TMP_Text>();
        
        
        gameObject.SetActive(false);

    }

    public void Refresh(Gun gun)
    {
        if (DmgValue == null)
            Load();
        Gun = gun;
        
        DmgValue.text = "" + (Gun.Damage - Gun.Damage % 1);
        DmgMod.text = "" + (Gun.DamageModifier - Gun.DamageModifier % 1) + "%";
        DmgBase.text = "" + (Gun.BaseDamage - Gun.BaseDamage % 1);

        ForceValue.text = "" + (Gun.Force - Gun.Force % 1);
        ForceMod.text = "" + (Gun.ForceModifier - Gun.ForceModifier % 1) +"%";
        ForceBase.text = "" + Gun.ForceModifier;

        BPSValue.text = "" + (Gun.BPS - Gun.BPS % 1);
        BPSMod.text = "" + (Gun.BulletDelayModifier - Gun.BulletDelayModifier % 1) + "%";
        BPSBase.text = "" + Gun.BaseBPS;

        ClipValue.text = "" + (Gun.ClipSize - Gun.ClipSize % 1);
        ClipMod.text = "" + (Gun.ClipSizeModifier - Gun.ClipSizeModifier % 1) + "%";
        ClipBase.text = "" + Gun.BaseClipSize;

        ReloadValue.text = "" + (Gun.ReloadTime - Gun.ReloadTime % 1);
        ReloadMod.text = "" + (Gun.ReloadTimeModifier - Gun.ReloadTimeModifier % 1) + "%";
        ReloadBase.text = "" + Gun.BaseReloadTime;

        Accuracy.text = "" + (Gun.Accuracy - Gun.Accuracy % 1) + "%";
        Stability.text = "" + (Gun.Stability - Gun.Stability % 1) + "%";
        Bullets.text = "" + Gun.Bullets;    
        Ricochet.text = "" + Gun.Ricochet;
    }
}
