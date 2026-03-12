using UnityEngine;
using System.Collections.Generic;

using Random = UnityEngine.Random;

public class ParticlesController : MonoBehaviour
{
     [Header("Particle Prefab")]
    public GameObject particlePrefab;          

    [Header("System Settings (editable from Inspector)")]
    [SerializeField] private int particleCount;             
    public float initialSpeed = 6f;            
    public float initialAngle ;
    public float initialAngleZ;
    public float lifetime = 3f;
    [SerializeField] private float gravity ;               
    public bool randomAngle = true;

    public List<GameObject> particles = new List<GameObject>();

   
    public static ParticlesController instance;

    private void Start()
    {
        CreateParticleExplotion();
        instance = this;

    }

    void Update()
    {
        //DestroyParticles();
        
        UpdateParticle();
    }

    public void CreateParticleExplotion()
    {
        particles = new List<GameObject>();
        
        

        for (int i = 0; i < particleCount; i++)
        {
            Debug.Log("Creating particle explosion with " + particleCount + " particles.");
            
            GameObject particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
            Particle p = particle.GetComponent<Particle>();

            if (p == null)
            {
                Destroy(particle);
                continue;
            }
            
            p.velocity0 = Random.Range(initialSpeed * 0.5f, initialSpeed * 1.5f);
            p.timeAliveMax = Random.Range(lifetime * 0.5f, lifetime * 1.5f);
            //p.gravity = gravity;
            
            p.transform.position = transform.position;
            particles.Add(particle);
        }
    }

    public void UpdateParticle()
    {
        List<GameObject> particlesToRemove = new List<GameObject>();
        foreach (GameObject particle in particles)
        {
            Particle p = particle.GetComponent<Particle>();
            if (p == null) continue;

            UpdateParticlePosition(p, Time.deltaTime);

            if (p.timeAlive >= p.timeAliveMax)
            {
                particlesToRemove.Add(particle);
            }
        }

        foreach (GameObject particle in particlesToRemove)
        {
            particles.Remove(particle);
            Destroy(particle);
        }
        if (particles.Count == 0)
        {
            
        }
    }
    
    public void UpdateParticlePosition(Particle p, float time)
    {
        p.timeAlive += time;    
        p.transform.position = p.CalculatePosition(p.timeAlive);
    }
    
}
