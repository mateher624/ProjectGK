using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject wonGame;
    public GameObject lostGame;

    private int zombieCount;

    void Start()
    {
        zombieCount = GameObject.FindGameObjectsWithTag("Dummie").Length;
        Cursor.visible = false;
    }

    public void deleteZombie()
    {
        zombieCount--;
        Debug.Log("Zombie count: " + zombieCount);
        if (zombieCount <= 0)
        {
            wonGame.SetActive(true);
            StartCoroutine("lol");
        }
    }

    public void playerDied()
    {
        lostGame.SetActive(true);
        StartCoroutine("lol");
    }

    IEnumerator lol()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu 3D");
    }
}
