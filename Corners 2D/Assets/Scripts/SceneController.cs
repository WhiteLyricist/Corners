using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField] private GameObject _black;
    [SerializeField] private GameObject _white;
    [SerializeField] private GameObject _empty;

    [SerializeField] private GameObject _winner;
    [SerializeField] private GameObject _check;

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

                cells[i, j].GetComponent<Stroke>().SetPosition(i, j);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;

                cells[i, j].transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Stroke.OnClick += Check;
        Stroke.OnChange += Change;
        Stroke.OnClear += Clear;
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

        cells[changeX, changeY].GetComponent<Stroke>().SetPosition(changeX, changeY);
        cells[a, b].GetComponent<Stroke>().SetPosition(a, b);



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

        _winner.GetComponent<Winner>().WinWhite(cells);
        _winner.GetComponent<Winner>().WinBlack(cells);
    }

    void Check(int a, int b, GameObject _c)
    {
        changeX = a;
        changeY = b;

        _check.GetComponent<Check>().CheckGoes(a, b, _c, cells);
    }

    private void OnDestroy()
    {
        Stroke.OnClick -= Check;
        Stroke.OnChange -= Change;
        Stroke.OnClear -= Clear;
    }

}
