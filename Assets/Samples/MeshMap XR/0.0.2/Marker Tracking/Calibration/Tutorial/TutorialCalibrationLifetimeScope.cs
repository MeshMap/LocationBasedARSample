#if (MAGICLEAP) && !(METAQUEST) && !(XREAL)
using VContainer;
using VContainer.Unity;

namespace MeshMap.MagicLeap2.Samples.MarkerTracking
{
    public class TutorialCalibrationLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<TutorialCalibrationModel>();
            builder.RegisterComponentInHierarchy<TutorialCalibrationController>();
        }
    }
}
#endif