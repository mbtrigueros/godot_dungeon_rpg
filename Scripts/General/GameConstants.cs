// Here we store the constant values of the game, like the animation names, and the inputs. We put them in UPPERCASE so everyone knows this variables cannot change. 
public class GameConstants
{
    // Animations
    public const string ANIM_IDLE = "Idle";
    public const string ANIM_MOVE = "Move";
    public const string ANIM_DASH = "Dash";
    public const string ANIM_ATTACK = "Attack";
    public const string ANIM_DEATH = "Death";
    public const string ANIM_EXPAND = "Expand";
    public const string ANIM_EXPLOSION = "Explosion";
    public const string ANIM_STUN = "Stun";

    // Inputs
    public const string INPUT_MOVE_LEFT = "MoveLeft";
    public const string INPUT_MOVE_RIGHT = "MoveRight";
    public const string INPUT_MOVE_FORWARD = "MoveForward";
    public const string INPUT_MOVE_BACKWARD = "MoveBackward";
    public const string INPUT_DASH = "Dash";
    public const string INPUT_ATTACK = "Attack";
    public const string INPUT_PAUSE = "Pause";
    public const string INPUT_INTERACT = "Interact";

    // Notifications
    public const int NOTIFICATION_ENTER_STATE = 5001;
    public const int NOTIFICATION_EXIT_STATE = 5002;

}