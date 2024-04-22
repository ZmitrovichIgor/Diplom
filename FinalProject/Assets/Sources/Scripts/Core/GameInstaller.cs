using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PauseService>()
            .FromComponentInNewPrefabResource(AssetsPath.ServicePath.PauseService)
            .AsSingle();
    }
}
