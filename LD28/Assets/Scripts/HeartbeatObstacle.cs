using UnityEngine;
using System.Collections;

/// <summary>
/// component 'HeartbeatObstacle'
/// ADD COMPONENT DESCRIPTION HERE
/// </summary>
[AddComponentMenu("Scripts/HeartbeatObstacle")]
public class HeartbeatObstacle : MonoBehaviour
{

    public HeartbeatGame game;
    void OnTriggerEnter2D(Collider2D other)
    {
        game.Hit();
    }
    
}
