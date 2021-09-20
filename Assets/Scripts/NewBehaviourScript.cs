using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /// Örnek bir Integer Tanýmlayalým (2 farklý þekilde) ////
        List<string> cs = new List<string>();
        cs.Add("hamza");
        cs.Add("elif");
        cs.RemoveAt(1);
        cs.Remove("hamza");
        cs.Add("mehmet");
        cs.Remove("hamza");
        foreach (var item in cs)
        {
            Debug.Log(item);
        }

        //int sayi = 10;
        //// Bu deðiþkeni aþaðýda ki þekilde de 
        //// uzun yolla tanýmlayabiliriz.


        //int sayi;
        //sayi = 10;

        ///// YANLIÞ ÝÞLEMLER & YANLIÞ TANIMLAMA ÞEKÝLLERÝ ////

        //int = sayi;  //bu deðiþkenin ismi yoktur
        //int = 1;     //burada da deðer var ama isim yok
        //int i = 1    //noktalý virgül yok (hata verir)
        //int 5 = 10;  //Veri tipi sayý ile baþlayamaz


        ///// Birden Fazla Deðiþkeni Ayný Anda Tanýmlama ////

        //int rakam1, rakam2, rakam3;

        //int sayi1 = 10, sayi2 = 15;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
