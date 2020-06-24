using Assets.Scripts.Api;
using Assets.Scripts.Models;
using Zenject;

public class DeafaultInstaller : MonoInstaller
{
    public override void InstallBindings()
    {

        //Container.Bind<ConfigHelper>().AsSingle().NonLazy();
        //Container.Bind<LoggedInUserModel>().AsSingle().NonLazy();
        //Container.Bind<IEventAggregator>().To<LoggedInUserModel>().AsSingle();
        Container.Bind<ILoggedInUserModel>().To<LoggedInUserModel>().AsSingle();
        Container.Bind<IAPIHelper>().To<APIHelper>().AsSingle();
    }



}