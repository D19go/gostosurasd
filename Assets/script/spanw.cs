using System.Collections;
using UnityEngine;

public class spanw : MonoBehaviour
{
    public GameObject inimigo;
    public GameObject inimigo2;
    public GameObject inimigo3;

    public GameObject Boss1;
    public GameObject Boss2;
    public GameObject Boss3;
    public GameObject canvas;

    public bool PodeWave = false;
    public int Wave = 0;
    public int total = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnNewMob();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PodeWave)
        {
            return;
        }

        if (total >= 9)  // Alterado para gerar 9 inimigos no total
        {
            // timeSpanw();
            for (int i = 0; i < 3; i++)
            {
                SpawnEnemy(inimigo, i);
                SpawnEnemy(inimigo2, i);
                SpawnEnemy(inimigo3, i);
            }
            Wave += 1;
            total = 0;
            canvas.GetComponent<MissoesP1>().Wave();
            // spawnNewMob();
        }
        
        // if(Wave == 3){
        //     CriarBoss();
        // }
        if(Wave == 4){
            CriarBoss();
        }
        if(Wave == 6){
            CriarBoss();
        }
        
    }
    void SpawnEnemy(GameObject enemyPrefab, int positionIndex)
    {
        if(total >= 9){

            // Instancie o inimigo
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Ajuste as coordenadas de deslocamento
            float offsetX = Random.Range(20f, 900f); // Altere conforme necessário
            float offsetZ = Random.Range(20f, 900f); // Altere conforme necessário

            newEnemy.transform.position = new Vector3(offsetX, 11, offsetZ);

            // Adicione a força
            newEnemy.GetComponent<Rigidbody>().AddForce(Vector3.up * 2000);
        }
    }

    // IEnumerator timeSpanw(){
    //     yield return new WaitForSeconds(1f);
    //     if(total >= 9){
    //         for (int i = 0; i < 3; i++){
    //             SpawnEnemy(inimigo, i);
    //             SpawnEnemy(inimigo2, i);
    //             SpawnEnemy(inimigo3, i);
    //         }
    //     }
       
    // }

    void CriarBoss()
    {   
        Debug.Log("n");
        if(Wave == 3){
            Boss1.SetActive(true);

        }
        if(Wave == 4){
            Boss2.SetActive(true);

        }
        if(Wave == 6){
            Boss3.SetActive(true);

        }

    }

    public void Comeca(bool missaoDarPulos)
    {
        PodeWave = missaoDarPulos;
    }

    public void Quantos(int menos1)
    {
        total += menos1;
    }

    void spawnNewMob()
    {
        // Não é mais necessário ajustar a posição do transform
    }
}
