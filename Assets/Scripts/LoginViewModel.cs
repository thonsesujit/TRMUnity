using Assets.Scripts.Api;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoginViewModel : MonoBehaviour
{
    public InputField UserName;
    public InputField Password;
    public Button logginButton;
    private IAPIHelper _apiHelper;
    //private IEventAggregator _events;


    // Start is called before the first frame update
    void Start()
    {
        logginButton.onClick.AddListener(() => {
            LogIn();
        });
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
            var result = await _apiHelper.Authenticate(un, pw );
            Debug.Log("User Authenticated" + result);
            await _apiHelper.GetLoggedInUserInfo(result.Access_Token);
            //_events.GetEvent<LogOnEvent>().Publish();

        }
        catch (System.Exception ex)
        {

            Debug.Log(ex);
        }

    }

    private string  _errorMessage;

    public string  ErrorMessage
    {
        get { return _errorMessage; }
        set { _errorMessage = value; }
    }


}
