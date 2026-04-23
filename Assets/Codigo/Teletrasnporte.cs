using UnityEngine;

public class Teletransporte : MonoBehaviour
{
    [Header("Configurações de Destino")]
    public Transform pontoDeDestino; // Arrastas o "Destino_Sala2" para aqui no Inspector

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no gatilho tem a Tag "Player"
        if (other.CompareTag("Player"))
        {
            // Tenta encontrar o Character Controller no Jogador
            CharacterController cc = other.GetComponent<CharacterController>();

            if (cc != null && pontoDeDestino != null)
            {
                // 1. Desliga o controlador (obrigatório para teleportar)
                cc.enabled = false;

                // 2. Muda a posição para o destino
                other.transform.position = pontoDeDestino.position;

                // 3. Opcional: Muda a rotação para o jogador olhar para a frente na nova sala
                other.transform.rotation = pontoDeDestino.rotation;

                // 4. Volta a ligar o controlador
                cc.enabled = true;

                Debug.Log("Teletransporte concluído para: " + pontoDeDestino.name);
            }
            else
            {
                Debug.LogWarning("Falta atribuir o Ponto de Destino no Inspector!");
            }
        }
    }
}