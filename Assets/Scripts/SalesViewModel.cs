using UnityEngine;
using UnityEngine.UI;

public class SalesViewModel : MonoBehaviour
{
    public Text DisplayText;
    public GameObject SalesScreen;


    void Start()
    { 
        LoginViewModel.LoggedIn += Loggedin;

    }

    private void OnDestroy()
    {
        LoginViewModel.LoggedIn += Loggedin;
    }


    private void ToggleLoginScreenActive()
    {
        SalesScreen.SetActive(true);
    }

    private void ToggleLoginScreenUnactive()
    {
        SalesScreen.SetActive(false);
    }



    public void Loggedin()
    {
        SalesScreen.SetActive(true);

        Debug.Log("Sales view model active");
        DisplayText.text = "Successfully logged into the API";
    }





}
