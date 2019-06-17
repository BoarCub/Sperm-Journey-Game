using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InstructionsViewer : MonoBehaviour
{

    public GameObject general;
    public GameObject vagina;
    public GameObject cervix;
    public GameObject uterus;
    public GameObject tubes;

    public TMPro.TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInstruction()
    {
        if(dropdown.value == 0)
        {
            general.SetActive(true);
            vagina.SetActive(false);
            cervix.SetActive(false);
            uterus.SetActive(false);
            tubes.SetActive(false);
        }
        else if (dropdown.value == 1)
        {
            general.SetActive(false);
            vagina.SetActive(true);
            cervix.SetActive(false);
            uterus.SetActive(false);
            tubes.SetActive(false);
        }
        else if (dropdown.value == 2)
        {
            general.SetActive(false);
            vagina.SetActive(false);
            cervix.SetActive(true);
            uterus.SetActive(false);
            tubes.SetActive(false);
        }
        else if (dropdown.value == 3)
        {
            general.SetActive(false);
            vagina.SetActive(false);
            cervix.SetActive(false);
            uterus.SetActive(true);
            tubes.SetActive(false);
        }
        else if (dropdown.value == 4)
        {
            general.SetActive(false);
            vagina.SetActive(false);
            cervix.SetActive(false);
            uterus.SetActive(false);
            tubes.SetActive(true);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

}
