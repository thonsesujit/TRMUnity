using Assets.Scripts.Api;
using Assets.Scripts.Models;
using Zenject;

public class DeafaultInstaller : MonoInstaller<DeafaultInstaller>
{
    public override void InstallBindings()
    {

        Container.Bind<ILoggedInUserModel>().To<LoggedInUserModel>().AsSingle();
        Container.Bind<IAPIHelper>().To<APIHelper>().AsSingle();
    }



}