using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Rover
    {
        public Rover(int coordinateX, int coordinateY, EDirection direction) =>
            (_coordinateX, _coordinateY, _direction) = (coordinateX, coordinateY, direction);

        private EDirection _direction;
        private int _coordinateX;
        private int _coordinateY;

        public void Operate(List<EAction> actions, Terrain terrain)
        {
            foreach (var action in actions)
            {
                switch (action)
                {
                    case EAction.L or EAction.R:
                        Turn(action);
                        break;
                    case EAction.M:
                        Move(terrain);
                        break;
                }
            }
        }
        
        private void Move(Terrain terrain){

            var newCoordinateX = _coordinateX;
            var newCoordinateY = _coordinateY;

            switch (_direction)
            {
                case EDirection.N:
                    newCoordinateY ++;
                    break;
                case EDirection.S:
                    newCoordinateY --;
                    break;
                case EDirection.E:
                    newCoordinateX ++;
                    break;
                case EDirection.W:
                    newCoordinateX --;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_direction), _direction, "Direction not found!");
            }

            if (!terrain.AvailableToMove(newCoordinateX, newCoordinateY)) return;
            
            _coordinateX = newCoordinateX;
            _coordinateY = newCoordinateY;
        }

        private void Turn(EAction action)
        {
            switch (action)
            {
                case EAction.R:

                    //cycle to North
                    if (Convert.ToInt32(_direction) + 1 > 3)
                    {
                        _direction = EDirection.N;
                    }
                    else
                    {
                        _direction = (EDirection)(Convert.ToInt32(_direction) + 1);
                    }

                    break;
                case EAction.L:
                    
                    //cycle to West
                    if (Convert.ToInt32(_direction) - 1 < 0)
                    {
                        _direction = EDirection.W;
                    }
                    else
                    {
                        _direction = (EDirection)(Convert.ToInt32(_direction) - 1);
                    }

                    break;
                case EAction.M:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, "Action not found!");
            }
        }

        public override string ToString(){
            return $"{_coordinateX} {_coordinateY} {_direction}";
        }
    }
}