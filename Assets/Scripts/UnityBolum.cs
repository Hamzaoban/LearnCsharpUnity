using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnityBolum : MonoBehaviour
{
    [SerializeField] string which;
    public Sprite[] BolumImage;
    private GameObject Yol;
    private string BolumName;

    public Color32 AcikBolumlerinRengi;
    public Color32 KapaliBolumlerinRengi;

    void Start()
    {
        BolumName = gameObject.name;
        Yol = gameObject.transform.GetChild(1).gameObject;
        
        if (PlayerPrefs.GetInt("FirstEntry") == 0)
        {
            PlayerPrefs.SetInt(BolumName, 0);
            
        }

        PlayerPrefs.SetInt("FirstEntry", 1);

        if (BolumName == "C#-1")
        {
            PlayerPrefs.SetInt(BolumName, 1);
        }
        
        
    }
    
    public void SahneyeGit(int SahneNumarası)
    {

        SceneManager.LoadScene(SahneNumarası);
    }

    public void BolumRengiAyarla()
    {
        if (PlayerPrefs.GetInt(BolumName) == 1)
        {
            GetComponent<Image>().sprite = BolumImage[0];
            Yol.GetComponent<Image>().color = new Color32(0, 255, 39, 255);
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = AcikBolumlerinRengi;
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Image>().sprite = BolumImage[1];
            Yol.GetComponent<Image>().color = new Color32(255,0, 0, 255);
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = KapaliBolumlerinRengi;
            GetComponent<Button>().interactable = false; 
        }
    }

    void Update()
    {
        BolumRengiAyarla();
    }
}
