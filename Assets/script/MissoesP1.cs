using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissoesP1 : MonoBehaviour
{

    public TextMeshProUGUI textoTela;

    public GameObject spanwEnemy;
    public GameObject Enemy;

    bool missao_pegar_moedas = true;
    bool missaoo_dar_pulos = false;
    // bool missao_chegar_final = false;

    int Pedras_pegas = 0;
    int Pedras_objetivo = 4;

    int Waves_Total = 0;
    int Waves_objetivo = 5;

    // int Boss_dados = 0;
    // int Boss_objetivo = 3;
    

    // Start is called before the first frame update
    void Start()
    {
        Enemy.SetActive(false);
        ListaMissoes();
    }

    public void ListaMissoes(){
        if( missao_pegar_moedas == true ){
            textoTela.text = "<b>Ache 4 Pedras espalhadas pelo mapa</b>\nPedras "+Pedras_pegas+"/"+Pedras_objetivo;
            if( Pedras_pegas >= Pedras_objetivo ){
                missaoo_dar_pulos = true;
                spanwEnemy.GetComponent<spanw>().Comeca(missaoo_dar_pulos);
                
                Enemy.SetActive(true);
            }
        }
        if( missaoo_dar_pulos == true ){
            textoTela.text = "<b>Proteja a Árvore Mãe!</b>\nPulos "+Waves_Total+"/"+Waves_objetivo;
            Enemy.SetActive(false);
            if(Waves_Total >= Waves_objetivo){
                textoTela.text = "<b>PARABÉNS VOCÊ CONSEGUIU</b>";
            }
        }
    }

    public void pegaPedras(){
        Pedras_pegas += 1;
        ListaMissoes();
    }

    public void Wave(){
        Waves_Total += 1;
        ListaMissoes();
    }

}