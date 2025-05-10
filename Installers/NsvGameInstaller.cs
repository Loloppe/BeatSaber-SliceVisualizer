using JetBrains.Annotations;
using SliceVisualizer.Core;
using SliceVisualizer.Factories;
using Zenject;

namespace SliceVisualizer.Installers
{
    [UsedImplicitly]
    internal class NsvGameInstaller : Installer
    {
        public NsvGameInstaller()
        {
        }

        public override void InstallBindings()
        {
            Container.BindFactory<NsvSlicedBlock, NsvBlockFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<NsvController>().AsSingle();
        }
    }
}