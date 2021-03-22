using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField] private GameObject _black;
    [SerializeField] private GameObject _white;
    [SerializeField] private GameObject _empty;

    private const float offsetX = 1f;
    private const float offsetY = 1f;

    private int changeX;
    private int changeY;

    private float posX;
    private float posY;

    private GameObject _changeTemp;

    private GameObject[,] cells;

    private void Awake()
    {
        cells = new GameObject[8, 8];

        Vector3 startPos = _black.transform.position;;

        for (int i = 0; i <= 7; i++) 
        {
            for (int j = 0; j <= 7; j++) 
            {
                if ((i < 3) && (j < 3))
                {
                    cells[i, j] = Instantiate(_black) as GameObject;
                    cells[i, j].GetComponent<CircleCollider2D>().enabled = false;
                }
                else
                {
                    if ((i > 4) && (j > 4))
                    {
                        cells[i, j] = Instantiate(_white) as GameObject;
                    }
                    else 
                    {
                        cells[i, j] = Instantiate(_empty) as GameObject;
                        cells[i, j].GetComponent<SpriteRenderer>().enabled=false;
                    }
                }

                cells[i, j].GetComponent<Parameters>().SetPosition(i, j);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;

                cells[i, j].transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Parameters.OnClick += Check;
        Parameters.OnChange += Change;
        Parameters.OnClear += Clear;
    }

    void Clear() 
    {

        var objs = GameObject.FindGameObjectsWithTag("3");

        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].tag = "0";
            objs[i].GetComponent<SpriteRenderer>().enabled = false;

        }
    }

    void Change(int a, int b, GameObject _c)
    {

        _changeTemp = cells[a, b];

        posX = cells[a, b].transform.position.x;
        posY = cells[a, b].transform.position.y;

        cells[a, b].transform.position = cells[changeX, changeY].transform.position;
        cells[changeX, changeY].transform.position = new Vector3(posX,posY,-1f);


        cells[a, b] = cells[changeX, changeY];
        cells[changeX, changeY] = _changeTemp;

        cells[changeX, changeY].GetComponent<Parameters>().SetPosition(changeX, changeY);
        cells[a, b].GetComponent<Parameters>().SetPosition(a, b);



        var _objs = GameObject.FindGameObjectsWithTag("3");

        for (int i = 0; i < _objs.Length; i++) 
        {
            _objs[i].tag = "0";
            _objs[i].GetComponent<SpriteRenderer>().enabled = false;

        }

        for (int i = 0; i <= 7; i++)
        {
            for (int j = 0; j <= 7; j++)
            {
                if (cells[i, j].tag != "0")
                {
                    cells[i, j].GetComponent<CircleCollider2D>().enabled = !cells[i, j].GetComponent<CircleCollider2D>().enabled;
                }
            }
        }

        WinWhite();
        WinBlack();

    }

    void Check(int a, int b, GameObject _c)
    {
        changeX = a;
        changeY = b;

        if ((b != 0))
        {
            if ((cells[a, b - 1].tag == "0"))
            {
                cells[a, b - 1].GetComponent<SpriteRenderer>().enabled = true;
                cells[a, b - 1].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                cells[a, b - 1].tag = "3";
            }
        }
        if (b<7){ 
            if ((cells[a, b + 1].tag == "0"))
            {
                cells[a, b + 1].GetComponent<SpriteRenderer>().enabled = true;
                cells[a, b + 1].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                cells[a, b + 1].tag = "3"; 
            }
        }
        if (a < 7) { 
            if ((cells[a + 1, b].tag == "0"))
            { 
                cells[a + 1, b].GetComponent<SpriteRenderer>().enabled = true;
                cells[a + 1, b].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                cells[a + 1, b].tag = "3";
            }
        }
        if (a !=0)
        {
            if ((cells[a - 1, b].tag == "0") )
            {
                cells[a - 1, b].GetComponent<SpriteRenderer>().enabled = true;
                cells[a - 1, b].GetComponent<SpriteRenderer>().material.color = Color.green * 10f;
                cells[a - 1, b].tag = "3";
            }
        }
    }

    private void WinBlack() 
    {
        for (int i = 5; i < 8; i++)
        {
            for (int j = 5; j < 8; j++)
            {
                if (cells[i, j].tag == "-1") { }
                else return;
            }
        }
        Debug.Log("Победа Чёрных!");
    }

    private void WinWhite() 
    {

        for (int i = 0; i < 3; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (cells[i, j].tag == "1") { }
                else return ;
            }
        }
        Debug.Log("Победа Белых!");
    }

    private void OnDestroy()
    {
        Parameters.OnClick -= Check;
        Parameters.OnChange -= Change;
        Parameters.OnClear -= Clear;
    }

}
