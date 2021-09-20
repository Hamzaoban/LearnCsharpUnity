using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AnamenuYonet : MonoBehaviour
{
    public GameObject CPanel;
    public GameObject UnityPanel;

    public void PanelAc(GameObject Panel)
    {
        Panel.SetActive(true);
    }
    public void PanelKapat(GameObject Panel)
    {
        Panel.SetActive(false);
    }

}
