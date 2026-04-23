using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LogicaLaser : MonoBehaviour
{
    public GameObject numeroDaSala;
    public GameObject teletransporte;
    public int maxRicochetes = 5;
    
    private LineRenderer lr;
    
    // NOVA VARIÁVEL: Diz ao jogo se o laser está ligado ou não
    private bool laserLigado = false; 
    private bool puzzleResolvido = false;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.red;
        lr.endColor = Color.red;

        // NOVO: Esconde a linha do laser quando o jogo começa
        lr.enabled = false; 

        if(numeroDaSala) numeroDaSala.SetActive(false);
        if(teletransporte) teletransporte.SetActive(false);
    }

    // NOVO: Se o jogador clicar no Emissor, o laser liga!
    void OnMouseDown()
    {
        if (!laserLigado)
        {
            laserLigado = true;
            lr.enabled = true; // Mostra a linha
            Debug.Log("SISTEMA DE ENERGIA ATIVADO!");
        }
    }

    void Update()
    {
        // NOVO: Só calcula e desenha o laser se ele estiver ligado e se ainda não ganhaste
        if (laserLigado && !puzzleResolvido)
        {
            DesenharLaser();
        }
    }

    void DesenharLaser()
    {
        Vector3 posicaoAtu = transform.position;
        Vector3 direcaoAtu = transform.forward; 

        lr.positionCount = 1;
        lr.SetPosition(0, posicaoAtu);

        for (int i = 0; i < maxRicochetes; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(posicaoAtu, direcaoAtu, out hit, 100f))
            {
                lr.positionCount++;
                lr.SetPosition(lr.positionCount - 1, hit.point);

                if (hit.collider.CompareTag("Espelho"))
                {
                    direcaoAtu = Vector3.Reflect(direcaoAtu, hit.normal);
                    posicaoAtu = hit.point;
                }
                else if (hit.collider.CompareTag("Recetor"))
                {
                    AtivarVitoria();
                    break;
                }
                else { break; } 
            }
            else
            {
                lr.positionCount++;
                lr.SetPosition(lr.positionCount - 1, posicaoAtu + direcaoAtu * 100f);
                break;
            }
        }
    }

    void AtivarVitoria()
    {
        puzzleResolvido = true; // Marca o puzzle como resolvido para o laser parar de calcular à toa
        lr.startColor = Color.green;
        lr.endColor = Color.green;
        if(numeroDaSala) numeroDaSala.SetActive(true);
        if(teletransporte) teletransporte.SetActive(true);
    }
}