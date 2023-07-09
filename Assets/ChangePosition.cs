using UnityEngine;

    public class ChangePosition : IMoveCommand
    {
        private Transform _pointToMove;

        public ChangePosition(Transform PointToMove)
        {
            _pointToMove = PointToMove;
        }
        

        public void Execute()
        {
            _pointToMove.transform.position = new Vector3(_transform.position.x,_pointToMove.transform.position.y,_pointToMove.transform.position.z);

        }

        public void OnExit()
        {
            throw new System.NotImplementedException();
        }
    }
