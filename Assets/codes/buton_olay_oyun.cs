using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Linq.Enumerable;

public class buton_olay_oyun : MonoBehaviour
{
    private int oyuncu_sayisi;



    public GameObject defter_cubuk;
    public GameObject ceza_panel;
    public GameObject kisi_panel;
    public GameObject ceza_yap_panel;
    public GameObject score_panel;



    private int cubuk_sayac = 1;
    private int kisi_say = 1;

    public  Dictionary<string, int> isim_skor = new Dictionary<string, int>();
    public List<string> isimler;
    public List<GameObject> oyuncular;
    public List<GameObject> cubuklar;
    public List<int> numaralar;
    public List<string> isim_kaydet;
    public List<string> skor_kaydet;
    public List<Text> skor_list;
    public List<int> skor_sirala;
    public List<string> isimler_list;
    

    public Text cubuk_text;

    public int kral;
    public Text kral_text;
    public Text kral_kisi_text;

    public InputField ceza_al;
    private string ceza;

    public List<GameObject> ceza_kisi;

    private int ceza_kisi_1;
    private int ceza_kisi_2;
    private int ceza_cek_1;
    private int ceza_cek_2;

    public Text ceza_yap_text;

    public GameObject cubuks;

    public GameObject gecis;
    public void yeni_oyun()
    {
        for (int i = 0; i < skor_kaydet.Count; i++)
        {
            PlayerPrefs.DeleteKey(skor_kaydet[i]);
        }
        
        SceneManager.LoadScene("oyun");
    }
    
    public void yapti()
    {
        PlayerPrefs.SetInt(skor_kaydet[ceza_cek_1], PlayerPrefs.GetInt(skor_kaydet[ceza_cek_1]) + 400);
        PlayerPrefs.SetInt(skor_kaydet[ceza_cek_2], PlayerPrefs.GetInt(skor_kaydet[ceza_cek_2]) + 400);
        PlayerPrefs.SetInt(skor_kaydet[kral], PlayerPrefs.GetInt(skor_kaydet[kral]) + 100);
        yeni_tur();
    }
    public void yapmadi()
    {
        PlayerPrefs.SetInt(skor_kaydet[ceza_cek_1], PlayerPrefs.GetInt(skor_kaydet[ceza_cek_1]) - 400);
        PlayerPrefs.SetInt(skor_kaydet[ceza_cek_2], PlayerPrefs.GetInt(skor_kaydet[ceza_cek_2]) - 400);
        PlayerPrefs.SetInt(skor_kaydet[kral], PlayerPrefs.GetInt(skor_kaydet[kral]) + 100);
        yeni_tur();
    }
    public void yeni_tur()
    {
        
        //Debug.Log(oyuncu_sayisi);
        //Debug.Log((PlayerPrefs.GetInt("tur_say")));
        if (PlayerPrefs.GetInt("tur_say")==(oyuncu_sayisi-1))
        {
            PlayerPrefs.SetInt("tur_say", 0);
            score_panel.SetActive(true);
            Debug.Log("oyun_bitti");
            gecis.GetComponent<gecis_sc>().gecis_ad();

            for (int i = 0; i < isimler.Count; i++)
            {
                skor_sirala.Add(PlayerPrefs.GetInt(skor_kaydet[i]));
                isim_skor.Add(isimler[i], skor_sirala[i]);
            }
            for (int b = 0; b < oyuncu_sayisi; b++)
            {
                int gecici;
                //string gecici_isim;

                

                

                for (int i = 0; i < skor_sirala.Count - 1; i++)
                {
                    for (int j = i; j < skor_sirala.Count; j++)
                    {

                        if (skor_sirala[i] < skor_sirala[j])
                        {

                            gecici = skor_sirala[j];
                            skor_sirala[j] = skor_sirala[i];
                            skor_sirala[i] = gecici;
                        }

                    }

                }



                

               
            }
            //skor_list[b].text = (b + 1).ToString() + ". " + isimler[b] + " Yapt��� Skor: " + skor_s�rala[b];

            //K���kten b�y��e do�ru s�ral�yor
            int z = 0;
            foreach (var author in isim_skor.OrderBy(key => key.Value))
            {
                //skor_list[z].text = (z + 1).ToString() + " ." + author.Key + "Yapt��� Skor" + author.Value;
                isimler_list.Add(author.Key);
                //skor_s�rala.Add(author.Value);
                z++;
                if (z == oyuncu_sayisi)
                {
                    break;
                }

            }
            isimler_list.Reverse();
            //skor_s�rala.Reverse();
            for (int b = 0; b < oyuncu_sayisi; b++)
            {
                skor_list[b].text = (b + 1).ToString() + ". " + isimler_list[b] + " Yapt��� Skor: " + skor_sirala[b];
            }
            
        }
        else
        {
            
            
            PlayerPrefs.SetInt("tur_say", PlayerPrefs.GetInt("tur_say")+1);
            defter_cubuk.SetActive(true);
            ceza_yap_panel.SetActive(false);
            SceneManager.LoadScene("oyun");
        }

       

    }
    public void ceza_olay()
    {
        ceza_yap_panel.SetActive(true);
        for (int i = 0; i < numaralar.Count; i++)
        {
            if (numaralar[i]==ceza_kisi_1)
            {
                ceza_cek_1 = i;
            }
            if (numaralar[i] == ceza_kisi_2)
            {
                ceza_cek_2 = i;
            }
        }
           
        
        ceza_yap_text.text = isimler[ceza_cek_1] + " ve " + isimler[ceza_cek_2] + " '" + ceza + "' cezas�n� yapacaklar.";
        
        
    }
    public void kisi_al(Object sender)
    {
        GameObject tiklanan_ = sender as GameObject;
        
        
        //Debug.Log(tiklanan_.GetComponentInChildren<Text>().text);
        
        if (kisi_say == 2)
        {
            
           
            ceza_kisi_2 = int.Parse(tiklanan_.tag);
            kisi_say = 1;
            kisi_panel.SetActive(false);
            ceza_olay();
            //Debug.Log("----------------");
            //Debug.Log(ceza_kisi_1);
            //Debug.Log(ceza_kisi_2);
            //Debug.Log("----------------");
            //Debug.Log(ceza_cek_1);
            //Debug.Log(ceza_cek_2);
            //Debug.Log("----------------");
        }
        if (kisi_say == 1)
        {
            
            ceza_kisi_1 = int.Parse(tiklanan_.tag);
            
            kisi_say++;
        }
        tiklanan_.SetActive(false);
        
    }
    public void ceza_belirle()
    {
        if (ceza_al.text=="")
        {

        }
        else
        {
            ceza = ceza_al.text;
            ceza_panel.SetActive(false);
            kisi_panel.SetActive(true);
            kral_kisi_text.text = "Kral " + isimler[kral] + " iki numara se�!";
            ceza_kisi[numaralar[kral]].SetActive(false);
            for (int i = oyuncu_sayisi; i < ceza_kisi.Count; i++)
            {
                ceza_kisi[i].SetActive(false);
            }
        }
    }
    public void kral_cubuk()
    {
        System.Random random = new System.Random();
        int kral_numara = Random.Range(0, oyuncu_sayisi );
        kral = kral_numara;
        for (int i = 0; i < oyuncu_sayisi; i++)
        {
           
            B:
            int cubuk_numara = Random.Range(0, oyuncu_sayisi );
            foreach (var item in numaralar)
            {
                if (cubuk_numara == item)
                {
                    goto B;
                }
            } 
            numaralar.Add(cubuk_numara);
          
            //Debug.Log(numaralar[i]);
            
            
        }
        //Debug.Log("------------");
        //Debug.Log(kral);
        //Debug.Log("------------");
        kral_text.text = "Kral " + isimler[kral]+ " cezay� belirle!";
    }
    public void cubuk_al(Object sender)
    {
        GameObject tiklanan = sender as GameObject;
        tiklanan.SetActive(false);
        if (cubuk_sayac==oyuncu_sayisi)
        {
           
            ceza_panel.SetActive(true);
            defter_cubuk.SetActive(false);
            kral_cubuk();
        }
        else
        {
            
           // Debug.Log("devam");
            cubuk_text.text = isimler[cubuk_sayac] + " bir �ubuk se�!";
            cubuk_sayac++;
        }
            
            
        
    }
    public void oyuncu_olusum()
    {
        for (int i = 0; i < oyuncu_sayisi; i++)
        {
            
            oyuncular[i].SetActive(true);
            cubuklar[i].SetActive(true);
            oyuncular[i].GetComponentInChildren<Text>().text = isimler[i];
            defter_cubuk.SetActive(true);
           
        }
        cubuk_text.text = isimler[0]+" bir �ubuk se�!";
    }
    

    public void eve_don()
    {
        
        SceneManager.LoadScene("menu");
    }

    
    // Start is called before the first frame update
    void Start()
    {
       
        oyuncu_sayisi = PlayerPrefs.GetInt("oyuncu_sayisi");

        for (int i = 0; i < PlayerPrefs.GetInt("oyuncu_sayisi"); i++)
        {
           // Debug.Log(PlayerPrefs.GetString(isim_kaydet[i]));
            isimler.Add(PlayerPrefs.GetString(isim_kaydet[i]));
          
        }


        

        defter_cubuk.SetActive(false);
        ceza_panel.SetActive(false);
        kisi_panel.SetActive(false);
        ceza_yap_panel.SetActive(false);
        score_panel.SetActive(false);
        for (int i = 0; i < oyuncular.Count; i++)
        {
            oyuncular[i].SetActive(false);
            cubuklar[i].SetActive(false);
        }
        oyuncu_olusum();
        for (int i = 0; i < oyuncu_sayisi; i++)
        {
            Debug.Log(PlayerPrefs.GetInt(skor_kaydet[i]));
        }


    }

    

}
