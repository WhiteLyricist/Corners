using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Winner : MonoBehaviour
{

    [SerializeField] private TMP_Text _text;

    public void WinWhite(GameObject[,] cells)
    {

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (cells[i, j].tag == "1") { }
                else return;
            }
        }
        _text.text="Победы Белых!";
        StartCoroutine(EndGame());

    }

    public void WinBlack(GameObject[,] cells)
    {
        for (int i = 5; i < 8; i++)
        {
            for (int j = 5; j < 8; j++)
            {
                if (cells[i, j].tag == "-1") { }
                else return;
            }
        }
        _text.text = "Победы Черных!";

        StartCoroutine(EndGame());
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Menu");
    }

}
