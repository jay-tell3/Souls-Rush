using EazyCamera;
using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public Player starterAssetsInputs;
        public EazyController easy;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            starterAssetsInputs.MoveInput(virtualMoveDirection);
        }

       public void VirtualLookInput(Vector2 virtualLookDirection)
        {

            easy.OrbitInput(virtualLookDirection);
          //  starterAssetsInputs.LookInput(virtualLookDirection);
        }

       

        public void VirtualRollInput(bool virtualSprintState)
        {
            starterAssetsInputs.RollInput(virtualSprintState);
        }

        public void VirtualPauseInput(bool virtualSprintState)
        {
            starterAssetsInputs.PauseInput(virtualSprintState);
        }

        public void VirtualAttacklInput(bool virtualSprintState)
        {
            starterAssetsInputs.AttackInput(virtualSprintState);
        }

        public void VirtualLockInput(bool virtualSprintState)
        {
            starterAssetsInputs.LockInput(virtualSprintState);
        }
    }

}
