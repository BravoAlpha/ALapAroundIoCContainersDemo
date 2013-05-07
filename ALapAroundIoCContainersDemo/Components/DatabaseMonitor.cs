using System;

namespace ALapAroundIoCContainersDemo.Components
{
    public enum DatabaseState
    {
        Down
    }

    // Based on a sample by Ayende http://ayende.com/blog/3633/windsor-ihandlerselector
    public static class DatabaseMonitor
    {
        public static event Action<DatabaseState> OnChangedState = delegate { };

        public static void ReportFailure()
        {
            OnChangedState(DatabaseState.Down);
        }
    }
}