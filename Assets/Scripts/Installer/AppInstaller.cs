using Controller;
using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerController>().AsSingle();
    }
}

