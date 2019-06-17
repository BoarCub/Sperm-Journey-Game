using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelChooser : MonoBehaviour
{

    public TMPro.TMP_Dropdown dropdown;
    
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void Begin()
    {
        SceneManager.LoadScene(2 + dropdown.value);
    }

}
