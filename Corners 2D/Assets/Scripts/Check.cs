using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public void CheckGoes(int a, int b, GameObject _c, GameObject[,] cells)
    {
        if ((b != 0))
        {
            if ((cells[a, b - 1].tag == "0"))
            {
                cells[a, b - 1].GetComponent<SpriteRenderer>().enabled = true;
                cells[a, b - 1].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                cells[a, b - 1].tag = "3";
            }
        }
        if (b < 7)
        {
            if ((cells[a, b + 1].tag == "0"))
            {
                cells[a, b + 1].GetComponent<SpriteRenderer>().enabled = true;
                cells[a, b + 1].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                cells[a, b + 1].tag = "3";
            }
        }
        if (a < 7)
        {
            if ((cells[a + 1, b].tag == "0"))
            {
                cells[a + 1, b].GetComponent<SpriteRenderer>().enabled = true;
                cells[a + 1, b].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                cells[a + 1, b].tag = "3";
            }
        }
        if (a != 0)
        {
            if ((cells[a - 1, b].tag == "0"))
            {
                cells[a - 1, b].GetComponent<SpriteRenderer>().enabled = true;
                cells[a - 1, b].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                cells[a - 1, b].tag = "3";
            }
        }

        switch (GameParameters.TypeGame) 
        {

            case 0: 
                    break;

            case 1:
                    if (b < 6)
                    {
                        if (cells[a, b].tag != cells[a, b + 1].tag && cells[a, b + 1].tag != "0" && cells[a, b + 1].tag != "3" && cells[a, b + 2].tag == "0")
                        {
                        cells[a, b + 2].GetComponent<SpriteRenderer>().enabled = true;
                        cells[a, b + 2].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                        cells[a, b + 2].tag = "3";
                        }
                     }

                    if (b > 1)
                    {
                        if (cells[a, b].tag != cells[a, b - 1].tag && cells[a, b - 1].tag != "0" && cells[a, b - 1].tag != "3" && cells[a, b - 2].tag == "0")
                        {
                            cells[a, b - 2].GetComponent<SpriteRenderer>().enabled = true;
                            cells[a, b - 2].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                            cells[a, b - 2].tag = "3";
                        }
                    }

                    if (a < 6)
                    {
                        if (cells[a, b].tag != cells[a + 1, b].tag && cells[a + 1, b].tag != "0" && cells[a + 1, b].tag != "3" && cells[a + 2, b].tag == "0" && a < 6)
                        {
                            cells[a + 2, b].GetComponent<SpriteRenderer>().enabled = true;
                            cells[a + 2, b].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                            cells[a + 2, b].tag = "3";
                        }
                    }

                    if (a > 1)
                    {
                        if (cells[a, b].tag != cells[a - 1, b].tag && cells[a - 1, b].tag != "0" && cells[a - 1, b].tag != "3" && cells[a - 2, b].tag == "0")
                        {
                            cells[a - 2, b].GetComponent<SpriteRenderer>().enabled = true;
                            cells[a - 2, b].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                            cells[a - 2, b].tag = "3";
                        }
                    }
                    break;

            case 2:
                    if (b < 6 && a < 6)
                    {
                        if (cells[a, b].tag != cells[a + 1, b + 1].tag && cells[a + 1, b + 1].tag != "0" && cells[a + 1, b + 1].tag != "3" && cells[a + 2, b + 2].tag == "0")
                        {
                            cells[a + 2, b + 2].GetComponent<SpriteRenderer>().enabled = true;
                            cells[a + 2, b + 2].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                            cells[a + 2, b + 2].tag = "3";
                        }
                    }
                    if (a < 6 && b > 1)
                    {
                        if (cells[a, b].tag != cells[a + 1, b - 1].tag && cells[a + 1, b - 1].tag != "0" && cells[a + 1, b - 1].tag != "3" && cells[a + 2, b - 2].tag == "0")
                        {
                            cells[a + 2, b - 2].GetComponent<SpriteRenderer>().enabled = true;
                            cells[a + 2, b - 2].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                            cells[a + 2, b - 2].tag = "3";
                        }
                    }
                    if (a > 1 && b < 6)
                    {
                        if (cells[a, b].tag != cells[a - 1, b + 1].tag && cells[a - 1, b + 1].tag != "0" && cells[a - 1, b + 1].tag != "3" && cells[a - 2, b + 2].tag == "0")
                        {
                            cells[a - 2, b + 2].GetComponent<SpriteRenderer>().enabled = true;
                            cells[a - 2, b + 2].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                            cells[a - 2, b + 2].tag = "3";
                        }
                    }

                    if (a > 1 && b > 1)
                    {
                        if (cells[a, b].tag != cells[a - 1, b - 1].tag && cells[a - 1, b - 1].tag != "0" && cells[a - 1, b - 1].tag != "3" && cells[a - 2, b - 2].tag == "0")
                        {
                            cells[a - 2, b - 2].GetComponent<SpriteRenderer>().enabled = true;
                            cells[a - 2, b - 2].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                            cells[a - 2, b - 2].tag = "3";
                        }
                    }
                    break;
        }
    }
}
