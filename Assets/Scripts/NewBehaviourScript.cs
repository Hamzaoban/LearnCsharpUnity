using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /// �rnek bir Integer Tan�mlayal�m (2 farkl� �ekilde) ////
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
        //// Bu de�i�keni a�a��da ki �ekilde de 
        //// uzun yolla tan�mlayabiliriz.


        //int sayi;
        //sayi = 10;

        ///// YANLI� ��LEMLER & YANLI� TANIMLAMA �EK�LLER� ////

        //int = sayi;  //bu de�i�kenin ismi yoktur
        //int = 1;     //burada da de�er var ama isim yok
        //int i = 1    //noktal� virg�l yok (hata verir)
        //int 5 = 10;  //Veri tipi say� ile ba�layamaz


        ///// Birden Fazla De�i�keni Ayn� Anda Tan�mlama ////

        //int rakam1, rakam2, rakam3;

        //int sayi1 = 10, sayi2 = 15;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
