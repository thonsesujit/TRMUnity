using Assets.Scripts.Api;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoginViewModel : MonoBehaviour
{
    public InputField UserName;
    public InputField Password;
    public Button logginButton;
    public GameObject logginScreen;
    private IAPIHelper _apiHelper;
    public static event Action LoggedIn = delegate { };

    public string ErrorMessage { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        LoggedIn += PrintTestForLogin;
        logginButton.onClick.AddListener(() =>
        {
            LogIn();
        });
    }

    private void OnDestroy()
    {
        LoggedIn -= PrintTestForLogin;
    }

    [Inject]
    public void Init(IAPIHelper apiHelper)
    {
        _apiHelper = apiHelper;
        //_events = events; IEventAggregator events
    }


    public async Task LogIn()
    {
        try
        {
            string un = UserName.text;
            string pw = Password.text;
            ErrorMessage = "";
            var result = await _apiHelper.Authenticate(un, pw);
            Debug.Log("User Authenticated" + result);
            await _apiHelper.GetLoggedInUserInfo(result.Access_Token);
            //_events.GetEvent<LogOnEvent>().Publish();
            LoggedIn?.Invoke();

        }
        catch (Exception ex)
        {

            Debug.Log(ex);
        }

    }

    //private void test()
    //{
    //    LoggedIn?.Invoke();

    //}

    private void PrintTestForLogin()
    {
        Debug.Log("Success in login view model");
        logginScreen.SetActive(false);

    }




}
