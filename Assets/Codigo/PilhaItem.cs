using UnityEngine;

public class PilhaItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // 1. Verifica se é o Player
        if (other.CompareTag("Player"))
        {
            // 2. Procura o script no objeto que tocou, ou nos "filhos" (objetos dentro dele)
            MecanicaLanterna lanterna = other.GetComponentInChildren<MecanicaLanterna>();

            // 3. Se ainda assim não encontrar, procura no objeto "pai" (caso o collider esteja num objeto filho)
            if (lanterna == null)
            {
                lanterna = other.GetComponentInParent<MecanicaLanterna>();
            }

            // 4. Se encontrou, executa a lógica
            if (lanterna != null)
            {
                lanterna.AdicionarPilhaAoInventario();
                Debug.Log("Pilha adicionada com sucesso!");
                Destroy(gameObject);
            }
            else
            {
                // Se aparecer esta mensagem, o script da lanterna não está no Jogador!
                Debug.LogError("ERRO: Toquei no Player, mas não encontrei o script MecanicaLanterna nele!");
            }
        }
    }
}