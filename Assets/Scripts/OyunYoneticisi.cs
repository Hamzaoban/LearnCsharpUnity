using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OyunYoneticisi : MonoBehaviour
{
    public string GecilecekBolum;

    public GameObject S1Canvas;
    public GameObject S2Canvas;
    public GameObject S3Canvas;

    public TextMeshProUGUI Soru;
    public TextMeshProUGUI BildinMi;
    public Button[] CevapButonları;
    public Sprite[] ButonImage;
    private int AktifSoruNumarasi;
    public int ChapterQuizNumber;


    private GameObject ListeG;
    public GameObject [] StoryRodPanel;
    public int ChapterTextNumber;
    public int ChapterImageNumber;
    private int ActiveChapterTextNumber;
    public string ChapterName;
    public string[] ChapterTexts;
    public string[] ChapterImages;
    public TextMeshProUGUI ChapterNameText;
    public GameObject ChapterText;
    private GameObject ChapterTextG;

    private GameObject KodCiktisiImage;
    public TextMeshProUGUI KodCiktisiText;
    public string[] KodCiktilari;
    
    public GameObject StoryRod;
    private GameObject StoryRodG;
    public Sprite AktifStoryRod;

    public string[] Sorular;
    public string[] Cevaplar;
    public string[] A;
    public string[] B;
    public string[] C;
    public string[] D;

    
    public void Touch()
    {
        //Eğer Dokunma Gerçekleştiyse Yapılacaklar
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    if (PlayerPrefs.GetInt("S") == 0)
                    {
                        if (ChapterTextNumber <= ActiveChapterTextNumber)
                        {
                            if (ActiveChapterTextNumber == ChapterTextNumber)
                            {
                                S1Canvas.transform.GetChild(4).gameObject.SetActive(true);
                                S1Canvas.transform.GetChild(1).gameObject.SetActive(false);
                            }
                            break;
                        }
                        StartCoroutine(AktifTextiAc(ActiveChapterTextNumber,ListeG));
                        StartCoroutine(StoryRoduAktiflestir(ActiveChapterTextNumber,StoryRodPanel[0]));
                        ActiveChapterTextNumber = ActiveChapterTextNumber + 1;
                        //S1 canvasındaki olayları gerçekleştir
                    }
                    else if (PlayerPrefs.GetInt("S") == 1)
                    {
                        if (ChapterImageNumber <= ActiveChapterTextNumber)
                        {
                            if (ActiveChapterTextNumber == ChapterImageNumber)
                            {
                                S2Canvas.transform.GetChild(5).gameObject.SetActive(true);
                                S2Canvas.transform.GetChild(1).gameObject.SetActive(false);
                            }
                            break;
                        }
                        ChapterImageShow(ActiveChapterTextNumber);
                        StartCoroutine(StoryRoduAktiflestir(ActiveChapterTextNumber, StoryRodPanel[1]));
                        
                        ActiveChapterTextNumber = ActiveChapterTextNumber + 1;
                        //S2 canvasındaki olayları gerçekleştir
                    }

                    
                }
            }
         
        }
    }

    IEnumerator StoryRoduAktiflestir(int ActiveNumber,GameObject gameObject)
    {

        gameObject.transform.GetChild(ActiveNumber).GetComponent<Image>().sprite = AktifStoryRod;
        yield return new WaitForSeconds(0.1f);

    }
    IEnumerator AktifTextiAc(int ActiveChaptertextNumber,GameObject PanelObj)
    {
       
        yield return new WaitForSeconds(0.1f);
        PanelObj.transform.GetChild(ActiveChaptertextNumber).GetComponent<TextMeshProUGUI>().text = ChapterTexts[ActiveChaptertextNumber];
        PanelObj.transform.GetChild(ActiveChaptertextNumber).gameObject.SetActive(true);

    }
   

    public void ChapterImageShow(int ChapterImageNumber)
    {
        if (!KodCiktisiImage.GetComponent<Image>().IsActive())
        {
            KodCiktisiImage.GetComponent<Image>().enabled = true;
        }
        KodCiktisiImage.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
        for (int i = 0; i < ChapterImages[ChapterImageNumber].Split('*').Length; i++)
        {
            KodCiktisiImage.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                KodCiktisiImage.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text 
                +"\n"+ ChapterImages[ChapterImageNumber].Split('*')[i];
        }

        KodCiktisiText.text = KodCiktilari[ChapterImageNumber];

    }
    
    public void CheckResult()
    {
        if (ChapterQuizNumber <= AktifSoruNumarasi)
        {

            return;
        }
        if (PlayerPrefs.GetString("Cevap") == Cevaplar[AktifSoruNumarasi])
        {
            //DoğruCevap
            Debug.Log("Doğru");
            BildinMi.text = "BRAVO DOGRU";
            BildinMi.color = new Color32(0, 255, 0, 255);
            StartCoroutine(StoryRoduAktiflestir(AktifSoruNumarasi, StoryRodPanel[2]));
            AktifSoruNumarasi++;
            StartCoroutine(SoruVeCevaplariYazdir(AktifSoruNumarasi,1));
        }
        else
        {
            //YanlışCevap,
            BildinMi.text = "YANLIS TEKRAR DENE";
            BildinMi.color = new Color32(255, 0, 0, 255);
            Debug.Log("Yanlış");
        }
    }
    public void AnamenuyeDon()
    {
        SceneManager.LoadScene("Anamenu");
    }

    public void Isaretle(GameObject Sik)
    {
        PlayerPrefs.SetString("Cevap", Sik.name);

        if (PlayerPrefs.GetString("Cevap") == CevapButonları[0].tag)
        {
            Sik.GetComponent<Image>().sprite = ButonImage[0];
            CevapButonları[1].GetComponent<Image>().sprite = ButonImage[1];
            CevapButonları[2].GetComponent<Image>().sprite = ButonImage[1];
            CevapButonları[3].GetComponent<Image>().sprite = ButonImage[1];
        }
        else if(PlayerPrefs.GetString("Cevap") == CevapButonları[1].tag)
        {
            Sik.GetComponent<Image>().sprite = ButonImage[0];
            CevapButonları[0].GetComponent<Image>().sprite = ButonImage[1];
            CevapButonları[2].GetComponent<Image>().sprite = ButonImage[1];
            CevapButonları[3].GetComponent<Image>().sprite = ButonImage[1];
        }
        else if(PlayerPrefs.GetString("Cevap") == CevapButonları[2].tag)
        {
            Sik.GetComponent<Image>().sprite = ButonImage[0];
            CevapButonları[1].GetComponent<Image>().sprite = ButonImage[1];
            CevapButonları[0].GetComponent<Image>().sprite = ButonImage[1];
            CevapButonları[3].GetComponent<Image>().sprite = ButonImage[1];
        }
        else
        {
            Sik.GetComponent<Image>().sprite = ButonImage[0];
            CevapButonları[1].GetComponent<Image>().sprite = ButonImage[1];
            CevapButonları[0].GetComponent<Image>().sprite = ButonImage[1];
            CevapButonları[2].GetComponent<Image>().sprite = ButonImage[1];
        }

    }

    public void ChapterCreate(int ChapterTextNumber,GameObject OlusanObje,GameObject OlusanObjeG,GameObject PanelS)
    {
        for (int i = 0; i < ChapterTextNumber; i++)
        {
            OlusanObjeG = Instantiate(OlusanObje, PanelS.transform);
            OlusanObjeG.SetActive(false);
        }
    }

    public void StoryRodCreate(int ChapterTextNumber,GameObject obje)
    {
        for (int i = 0; i < ChapterTextNumber; i++)
        {
            StoryRodG = Instantiate(StoryRod, obje.transform);
            
        }
    }

    IEnumerator SoruVeCevaplariYazdir(int SoruNum,float sn)
    {
        if (ChapterQuizNumber <= SoruNum)
        {
            S3Canvas.transform.GetChild(3).gameObject.SetActive(false);
            S3Canvas.transform.GetChild(5).gameObject.SetActive(true);
            BildinMi.text = "TEBRİKLER BÖLÜMÜ BİTİRDİNİZ...";
            Soru.text = "";
            CevapButonları[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            CevapButonları[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            CevapButonları[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            CevapButonları[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";

            yield break;
        }
        
        yield return new WaitForSeconds(sn);
        Soru.text = "";

        for (int i = 0; i < Sorular[SoruNum].Split('*').Length; i++)
        {
            Soru.text = Soru.text + "\n" + Sorular[SoruNum].Split('*')[i];
        }
        
        CevapButonları[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = A[SoruNum];
        CevapButonları[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = B[SoruNum];
        CevapButonları[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = C[SoruNum];
        CevapButonları[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = D[SoruNum];
        BildinMi.text = "";
    }
    void Start()
    {
        PlayerPrefs.SetInt("S", 0);

        ActiveChapterTextNumber = 0;
        //S1 canvası tanımlamaları
        ListeG = S1Canvas.transform.GetChild(2).GetChild(0).GetChild(0).gameObject;
        StoryRodPanel[0] = S1Canvas.transform.GetChild(3).gameObject;

        //S2 canvası tanımlamaları
        KodCiktisiImage = S2Canvas.transform.GetChild(3).gameObject;


        ChapterCreate(ChapterTextNumber,ChapterText,ChapterTextG,ListeG);
       

        StoryRodCreate(ChapterTextNumber,StoryRodPanel[0]);
        ChapterNameText.text = ChapterName;
        

    }


    public void BolumGec(int S)
    {
        if (S == 1)
        {
            ActiveChapterTextNumber = 0;
            PlayerPrefs.SetInt("S", 1);
            S1Canvas.SetActive(false);
            S2Canvas.SetActive(true);
            StoryRodCreate(ChapterImageNumber, StoryRodPanel[1]);
        }
        else if (S == 2)
        {
            ActiveChapterTextNumber = 0;
            PlayerPrefs.SetInt("S", 2);
            S2Canvas.SetActive(false);
            S3Canvas.SetActive(true);
            StoryRodCreate(ChapterQuizNumber, StoryRodPanel[2]);
            StartCoroutine(SoruVeCevaplariYazdir(AktifSoruNumarasi,0));
        }
        else
        {
            PlayerPrefs.SetInt(GecilecekBolum, 1);
            SceneManager.LoadScene(GecilecekBolum);

            PlayerPrefs.SetInt("S", 3);
            

        }
    }
    
    void Update()
    {
        Touch();
        
    }
}
