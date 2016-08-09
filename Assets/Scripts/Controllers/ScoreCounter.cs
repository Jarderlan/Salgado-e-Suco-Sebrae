using UnityEngine;
using System.Collections;

public class ScoreCounter 
{
    private static ScoreCounter scoreCounterInstance = null;
    private int meta;
    public float caixa;

    private ScoreCounter()
    {

    }

    public static ScoreCounter ScoreCounterProperties
    {
        get
        {
            if(scoreCounterInstance == null)
            {
                scoreCounterInstance = new ScoreCounter();
            }

            return scoreCounterInstance;
        }
    }

    public int GetInitialMetaMensal()
    {
        if (PlayerPrefs.GetInt("LevelId") == 0)
        {
            meta = 1000;
        }

        if (PlayerPrefs.GetInt("LevelId") == 1)
        {
            meta = 3000;
        }

        if (PlayerPrefs.GetInt("LevelId") == 2)
        {
            meta = 5000;
        }

        if (PlayerPrefs.GetInt("LevelId") == 3)
        {
            meta = 10000;
        }

        if (PlayerPrefs.GetInt("LevelId") == 4)
        {
            meta = 30000;
        }

        if (PlayerPrefs.GetInt("LevelId") == 5)
        {
            meta = 50000;
        }

        if (PlayerPrefs.GetInt("LevelId") == 6)
        {
            meta = 100000;
        }

        if (PlayerPrefs.GetInt("LevelId") == 7)
        {
            meta = 200000;
        }

        if (PlayerPrefs.GetInt("LevelId") == 8)
        {
            meta = 400000;
        }

        if (PlayerPrefs.GetInt("LevelId") == 9)
        {
            meta = 500000;
        }

        return meta;
    }

    public float GetCurrentCaixa()
    {
        return caixa;
    }

    public void SetCaixaPositive(float newCaixa)
    {
        //10% do faturamento
        caixa += newCaixa;
    }

    public void SetCaixaNegative(float newCaixa)
    {
        //10% do faturamento
        caixa -= newCaixa;
    }

    //caixa inicial de acordo com o nivel
    public float GetInitialCaixa()
    {
        float initialCaixa = 0;

        if (PlayerPrefs.GetInt("LevelId") == 0)
        {
            initialCaixa = 3000;
        }

        else
        {
            initialCaixa = PlayerPrefs.GetFloat("Caixa");
        }

        return initialCaixa;
    }
}
