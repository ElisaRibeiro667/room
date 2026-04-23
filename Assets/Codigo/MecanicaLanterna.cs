using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class MecanicaLanterna : MonoBehaviour
{
    public Light luzLanterna;
    public AudioSource somClique;
    public TextMeshProUGUI textoPilhas; // Removi a duplicata que estava no fim do código

    [Header("Configurações da Bateria")]
    public Slider barraBateria; 
    public float bateriaAtual = 100f;
    public float velocidadeConsumo = 2f; 
    public int quantidadePilhas = 0; // ERRO CORRIGIDO: Esta variável não estava declarada

    private bool ligada = true;

    void Update()
    {
        // Ligar/Desligar com a tecla F
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (bateriaAtual > 0) 
            {
                AlternarLanterna();
            }
        }

        // Recarregar com a tecla R (fora do IF da lanterna ligada para funcionar sempre)
        if (Input.GetKeyDown(KeyCode.R) && quantidadePilhas > 0)
        {
            RecarregarComPilha();
        }

        // Se estiver ligada, gasta bateria
        if (ligada)
        {
            bateriaAtual -= velocidadeConsumo * Time.deltaTime;

            // Se a bateria acabar, desliga
            if (bateriaAtual <= 0)
            {
                bateriaAtual = 0;
                DesligarLanternaForçado();
            }
        }

        // ATUALIZA A INTERFACE (UI)
        AtualizarUI();
    }

    void AtualizarUI()
    {
        if (barraBateria != null)
        {
            barraBateria.value = bateriaAtual;
        }

        if (textoPilhas != null)
        {
            textoPilhas.text = "Pilhas: " + quantidadePilhas;
        }
    }

    void AlternarLanterna()
    {
        ligada = !ligada;
        luzLanterna.enabled = ligada;
        if (somClique != null) somClique.Play();
    }

    void DesligarLanternaForçado()
    {
        ligada = false;
        luzLanterna.enabled = false;
    }

    public void Recarregar(float quantidade)
    {
        bateriaAtual += quantidade;
        if (bateriaAtual > 100) bateriaAtual = 100;
    }

    void RecarregarComPilha()
    {
        quantidadePilhas--; 
        bateriaAtual += 100f; 
        if (bateriaAtual > 100) bateriaAtual = 100;
        Debug.Log("Usaste uma pilha! Restam: " + quantidadePilhas);
    }

    public void AdicionarPilhaAoInventario()
    {
        quantidadePilhas++;
        Debug.Log("Ganhaste uma pilha! Total: " + quantidadePilhas);
    }
}