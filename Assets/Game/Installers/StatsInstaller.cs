using UnityEngine;
using Zenject;

public class StatsInstaller : MonoInstaller
{
    [SerializeField]
    private Energy _energy;

    [SerializeField]
    private Score _score;

    public override void InstallBindings()
    {
        Container.Bind<Energy>().FromInstance(_energy);
        Container.Bind<Score>().FromInstance(_score);
    }
}