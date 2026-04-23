using UnityEngine;

public class Vitoria : MonoBehaviour
{
    public GameObject painelVitoria; // Arrastamos o PainelVitoria para aqui depois

    private void OnTriggerEnter(Collider other)
    {
        // Se quem tocou no cubo invisível foi o Player
        if (other.CompareTag("Player"))
        {
            Debug.Log("O cientista escapou!");
            
            if (painelVitoria != null)
            {
                painelVitoria.SetActive(true); // Mostra a mensagem de vitória
            }

            Time.timeScale = 0f;          // Congela o tempo (o jogo para)
            Cursor.lockState = CursorLockMode.None; // Liberta o rato
            Cursor.visible = true;                  // Mostra o rato
        }
    }
}