using UnityEngine;
using XInputDotNetPure;
using System.Collections.Generic;

// Rumble (vibration) event
class xRumble
{
    public float timer;    // Rumble timer
    public float fadeTime; // Fade-out (in seconds)
    public Vector2 power;  // Rumble 'power'

    // Decrease timer
    public void Update()
    {
        this.timer -= Time.deltaTime;
    }
}

// Xbox 360 Gamepad class
public class x360_Gamepad : MonoBehaviour
{
    private GamePadState prev_state; // Previous gamepad state
    private GamePadState state;      // Current gamepad state
    private List<xRumble> rumbleEvents;

    public int gamepadIndex = 0;           // Numeric index (1,2,3 or 4)
    private PlayerIndex playerIndex;    // XInput 'Player' index

    void Start()
    {
        playerIndex = (PlayerIndex)gamepadIndex;
        rumbleEvents = new List<xRumble>();
    }

    // Update gamepad state
    void Update()
    {
        // Get current state
        state = GamePad.GetState(playerIndex);

        HandleRumble();

    }

    // Update and apply rumble event(s)
    void HandleRumble()
    {
        // Ignore if there are no events
        if (rumbleEvents.Count > 0)
        {
            Vector2 currentPower = new Vector2(0, 0);

            for (int i = 0; i < rumbleEvents.Count; ++i)
            {
                // Update current event
                rumbleEvents[i].Update();

                if (rumbleEvents[i].timer > 0)
                {
                    /*
                    float multiplier;
                    // Calculate current power
                    if (rumbleEvents[i].timer >= rumbleEvents[i].fadeTime)
                        multiplier = (rumbleEvents[i].timer / rumbleEvents[i].fadeTime);
                    else
                        multiplier = 0;
                        */

                    // Calculate current power
                    float timeLeft = Mathf.Clamp(rumbleEvents[i].timer / rumbleEvents[i].fadeTime, 0f, 1f);
                    currentPower = new Vector2(Mathf.Max(rumbleEvents[i].power.x * timeLeft, currentPower.x),
                                               Mathf.Max(rumbleEvents[i].power.y * timeLeft, currentPower.y));

                    // Apply vibration to gamepad motors
                    GamePad.SetVibration(playerIndex, currentPower.x, currentPower.y);
                }
                else
                {
                    // Remove expired event
                    rumbleEvents.Remove(rumbleEvents[i]);
                    if (rumbleEvents.Count <= 0)
                        GamePad.SetVibration(playerIndex, 0, 0);
                }
            }
        }
    }

    public void AddRumble(float timer, Vector2 power, float fadeTime = 0f)
    {
        xRumble rumble = new xRumble();

        rumble.timer = timer;
        rumble.power = power;
        rumble.fadeTime = fadeTime;

        // Add rumble event to container
        rumbleEvents.Add(rumble);
    }
}