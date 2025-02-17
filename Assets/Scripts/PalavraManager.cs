﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class PalavraManager : MonoBehaviour
{
    [SerializeField]
    Palavra[] palavras;


    private int vidasAtuais = 0;
    private const int TOTAL_DE_VIDAS = 8;
    public string PalavraEscolhida { get;private set;}
    public string DescricaoEscolhida {  get; private set; }

    public event Action<string, string> OnPalavraChange = delegate { };


    public char PLACEHOLDER = '*';
    void Awake()
    {
        EscolherPalavraAleatoria(); 
    }
    public bool CheckWinCondition(string userInput) { 
        return PalavraEscolhida.Equals(userInput); 
    }
    public bool CheckLoseCondition() { 
        return vidasAtuais == TOTAL_DE_VIDAS - 1; 
    }
    public void DrawNextHangmanPart()
    {
        vidasAtuais = ++vidasAtuais % TOTAL_DE_VIDAS;
        print(vidasAtuais);
        //HangmanImage.sprite = HangmanSprites[currentHangmanSprite];
    }


    private void EscolherPalavraAleatoria()
    {
        int randInt = UnityEngine.Random.Range(0, palavras.Length);
        PalavraEscolhida= palavras[randInt].palavra;
        DescricaoEscolhida = palavras[randInt].descricao;


        StringBuilder sb = new StringBuilder("");
        for (int i = 0; i < PalavraEscolhida.Length; i++) { 
        sb.Append(PLACEHOLDER);
            
        }
        OnPalavraChange(sb.ToString(), DescricaoEscolhida);
        Debug.Log("Answer: " + PalavraEscolhida);
    }
}
