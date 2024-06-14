using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Button start_btn;
    [SerializeField] Button exit_btn;
    void Start()
    {
        start_btn.onClick.AddListener(()=>{
            SceneManager.LoadScene("2D_PlatformerGame");
        });
        exit_btn.onClick.AddListener(()=>{
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
