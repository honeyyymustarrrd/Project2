using UnityEngine;
using Opsive.UltimateCharacterController.ThirdPersonController.Character.MovementTypes;

public class FixedCameraMovement : TopDown
{
    [Tooltip("固定移动方向的水平角度，可填写摄像机的 Y 旋转角度。")]
    [SerializeField] private float m_MovementYaw;

    private Quaternion MovementRotation =>
        Quaternion.Euler(0f, m_MovementYaw, 0f);

    public override float GetDeltaYawRotation(
        float characterHorizontalMovement,
        float characterForwardMovement,
        float cameraHorizontalMovement,
        float cameraVerticalMovement)
    {
        var input = new Vector3(
            characterHorizontalMovement, 0f, characterForwardMovement);

        if (input.sqrMagnitude < 0.0001f)
        {
            return 0f;
        }

        var direction = MovementRotation * input.normalized;
        var targetYaw = Quaternion.LookRotation(direction, Vector3.up).eulerAngles.y;

        return Mathf.DeltaAngle(
            m_CharacterLocomotion.Rotation.eulerAngles.y, targetYaw);
    }

    public override Vector2 GetInputVector(Vector2 inputVector)
    {
        var worldDirection = MovementRotation *
            new Vector3(inputVector.x, 0f, inputVector.y);

        var localDirection =
            Quaternion.Inverse(m_CharacterLocomotion.Rotation) * worldDirection;

        return Vector2.ClampMagnitude(
            new Vector2(localDirection.x, localDirection.z), 1f);
    }
}