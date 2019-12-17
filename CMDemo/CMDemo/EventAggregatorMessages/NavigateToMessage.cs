namespace CMDemo.EventAggregatorMessages
{
    public sealed class NavigateToMessage
    {
        public NavigateToMessage(NavigateToEnum navigateToEnum)
        {
            NavigateToEnum = navigateToEnum;
        }

        public NavigateToEnum NavigateToEnum { get; }
    }

    public enum NavigateToEnum
    {
        ThirdChildView,
        AnotherChildView
    }
}