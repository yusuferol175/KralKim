using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buton_olay_menu_sc : MonoBehaviour
{
    public GameObject defter_panel;
    public GameObject post_it_panel;
    public GameObject oyuncu_isim_panel;

    public Text oyuncu_gir_text;
    private int sayac = 1;

    public static int oyuncu_sayisi;

    public InputField isim_al;

    public List<string> isimler_menu;

    public List<string> isim_kaydet;

    private int isim_say=0;

    public GameObject ev_button;
    public void basla()
    {
        //SceneManager.LoadScene("oyun");
        defter_panel.SetActive(true);
        ev_button.SetActive(true);
    }

    public void devam_but()
    {
        if (isim_al.text == "")
        {

        }
        else
        {

            PlayerPrefs.SetString(isim_kaydet[isim_say],isim_al.text);
            isim_say++;
            isimler_menu.Add(isim_al.text);
            if (sayac == oyuncu_sayisi)
            {
                PlayerPrefs.SetInt("bannerdurum", 1);
                //oyuncu_olusum();
                SceneManager.LoadScene("oyun");
                
                
            }
            sayac++;
            oyuncu_gir_text.text = sayac.ToString() + ".Oyuncunun Adý:";
            isim_al.text = "";
        }


    }
    public void oyuncu_belirle()
    {
        post_it_panel.SetActive(false);
        oyuncu_isim_panel.SetActive(true);
        oyuncu_gir_text.text = sayac.ToString() + ".Oyuncunun Adý:";
        PlayerPrefs.SetInt("oyuncu_sayisi", oyuncu_sayisi);
    }
    public void oyuncu_3()
    {
        oyuncu_sayisi = 3;
        oyuncu_belirle();
    }
    public void oyuncu_4()
    {
        oyuncu_sayisi = 4;
        oyuncu_belirle();
    }
    public void oyuncu_5()
    {
        oyuncu_sayisi = 5;
        oyuncu_belirle();
    }
    public void oyuncu_6()
    {
        oyuncu_sayisi = 6;
        oyuncu_belirle();
    }
    public void oyuncu_7()
    {
        oyuncu_sayisi = 7;
        oyuncu_belirle();
    }
    public void oyuncu_8()
    {
        oyuncu_sayisi = 8;
        oyuncu_belirle();
    }
    public void oyuncu_9()
    {
        oyuncu_sayisi = 9;
        oyuncu_belirle();
    }
    public void oyuncu_10()
    {
        oyuncu_sayisi = 10;
        oyuncu_belirle();
    }
    
    public void ev_but()
    {
        SceneManager.LoadScene("menu");
    }
    // Start is called before the first frame update
    void Start()
    {
        defter_panel.SetActive(false);
        oyuncu_isim_panel.SetActive(false);
        ev_button.SetActive(false);

        PlayerPrefs.DeleteAll();
      
       

    }

}
