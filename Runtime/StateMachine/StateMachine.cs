namespace SpacegoatStudios.Core
{
    public class StateMachine : Observer
    {
        #region Private Variables

        private State _currentState;

        #endregion

        #region MonoBehaviour Methods

        private void OnAnimatorMove()
        {
            _currentState?.OnAnimatorMove();
        }

        private void Update()
        {
            _currentState?.OnUpdate();
        }

        private void FixedUpdate()
        {
            _currentState?.OnFixedUpdate();
        }

        private void LateUpdate()
        {
            _currentState?.OnLateUpdate();
        }

        #endregion

        #region Public Methods

        public void SwitchState(State state)
        {
            _currentState?.OnExit();
            _currentState = state;
            _currentState?.OnEnter();
        }

        #endregion
    }
}