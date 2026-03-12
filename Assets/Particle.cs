using UnityEngine;
using Random = UnityEngine.Random;

public class Particle : MonoBehaviour
{
    public float velocity0;       // Velocidad inicial
    public float angle0; // Ángulo de elevación (grados, 0=horizontal, 90=vertical)
    public float initialAngleZ; // Ángulo de rotación alrededor del eje Z (grados)
    public float timeAliveMax;    // Tiempo de vida máximo
    public float timeAlive;       // Tiempo que lleva activa
    public float gravity;         // Gravedad
    
    public float randomAngle0;
    public float randomAngleZ0;

    private void Start()
    {
        
        randomAngle0 = Random.Range(0, 361f) * Mathf.Deg2Rad;
        randomAngleZ0 = Random.Range(0, 361f) * Mathf.Deg2Rad;
        
    }

    public Vector3 CalculatePosition(float time)
    {
        if (ParticlesController.instance.randomAngle)
        {
            ParticlesController.instance.initialAngle = randomAngle0;
                ParticlesController.instance.initialAngleZ = randomAngleZ0;
        }
        else 
        {
            ParticlesController.instance.initialAngle = ParticlesController.instance.initialAngle ;
            Debug.Log(ParticlesController.instance.initialAngle);
            ParticlesController.instance.initialAngleZ = ParticlesController.instance.initialAngleZ;
            Debug.Log(ParticlesController.instance.initialAngleZ);
        }
        
        
        
        float pX = 0 + velocity0 * Mathf.Cos(ParticlesController.instance.initialAngle)  * time;
        float pY = 0 + velocity0 * Mathf.Sin(ParticlesController.instance.initialAngle) * time - (0.5f * (gravity * (time * time)));
        float pZ = 0 + velocity0 * Mathf.Cos(ParticlesController.instance.initialAngleZ )  * time;   
        
        
       
       
        
        return new Vector3(pX,pY, pZ);
    }
}

