using UnityEngine;

public class PlayerEffects : MonoBehaviour
{

    private Player player;



    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void PlayFootStepSFX()
    {

        if (player.movement.isRunning)
        {
            AudioManager.instance.PlaySFX(1, player.transform);
            AudioManager.instance.StopSFX(0);
        }
        else
        {
            AudioManager.instance.PlaySFX(0, player.transform);
            AudioManager.instance.StopSFX(1);
        }
    }

    public void StopFootStepSFX()
    {
        AudioManager.instance.StopSFX(1);
        AudioManager.instance.StopSFX(0);
    }



}
