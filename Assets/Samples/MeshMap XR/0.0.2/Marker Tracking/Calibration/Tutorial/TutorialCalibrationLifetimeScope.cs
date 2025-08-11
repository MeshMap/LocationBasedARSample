using VContainer;
using VContainer.Unity;

namespace MeshMap.XR.MarkerTracking.Samples
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