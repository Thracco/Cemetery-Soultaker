using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoulManager : MonoBehaviour
{
    public static SoulManager Instance;
    public TMP_Text PlayerSoulsText, EscapedSoulsText;
    public int PlayerSouls, EscapedSouls;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }  

    public void AddPlayerSouls(int souls)
    {
        PlayerSouls += souls;
        PlayerSoulsText.text = PlayerSouls.ToString();
    } 

    public void AddEscapedSouls(int souls)
    {
        EscapedSouls += souls;
        EscapedSoulsText.text = EscapedSouls.ToString();
    } 
    
          
}
