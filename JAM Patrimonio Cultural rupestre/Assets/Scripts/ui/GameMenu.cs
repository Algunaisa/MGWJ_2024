using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{
    private Button bJugar;
    private Button bHistoria;
    private Button bSalir;
    void Awake()
    {
        bJugar = GameObject.Find("BJugar").GetComponent<Button>();
        bHistoria = GameObject.Find("BHistoria").GetComponent<Button>();
        bSalir = GameObject.Find("BSalir").GetComponent<Button>();
    }
    void Start()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        bJugar.onClick.AddListener(Jugar);
        bHistoria.onClick.AddListener(Historia);
        bSalir.onClick.AddListener(Salir);
    }

    private void Jugar()
    {
        Debug.Log("Jugando");
        SceneManager.LoadSceneAsync(2);
    }

    private void Historia()
    {
        Debug.Log("Historia");
    }
    private void Salir()
    {
        Debug.Log("Salir");
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
