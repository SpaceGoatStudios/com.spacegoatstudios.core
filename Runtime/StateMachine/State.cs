namespace SpacegoatStudios.Core
{
    public abstract class State
    {
        public abstract void OnEnter(params object[] arguments);

        public abstract void OnAnimatorMove(params object[] arguments);
        public abstract void OnUpdate(params object[] arguments);
        public abstract void OnFixedUpdate(params object[] arguments);
        public abstract void OnLateUpdate(params object[] arguments);
        public abstract void OnExit(params object[] arguments);
    }
}