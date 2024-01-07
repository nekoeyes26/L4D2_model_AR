using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    public void Keluar()
    {
        Application.Quit();
        Debug.Log("Game Close");
    }

    public void Mainkan()
    {
        SceneManager.LoadScene("AR_Scene");
    }

    public void tentang()
    {
        SceneManager.LoadScene("Ui_tentang");
    }

    public void credit()
    {
        SceneManager.LoadScene("Ui_credit");
    }

    public void kembali()
    {
        SceneManager.LoadScene("Ui");
    }

}
