using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Radar : MonoBehaviour
    {
        [SerializeField]
        protected ParticleSystem radarParticles;

        protected Transform particleEmitterTransform;
        protected Transform playerTransform;

        private float desiredDistanceFromPlayer;

        void Start()
        {
            particleEmitterTransform = radarParticles.GetComponent<Transform>();
            playerTransform = GameManager.instance.Player.GetComponent<Transform>();
            desiredDistanceFromPlayer = particleEmitterTransform.position.x - playerTransform.position.x;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float distanceFromPlayer = particleEmitterTransform.position.x - playerTransform.position.x;
            if (distanceFromPlayer < desiredDistanceFromPlayer)
            {
                particleEmitterTransform.transform.Translate(new Vector3(playerTransform.position.x + desiredDistanceFromPlayer
                    , particleEmitterTransform.position.y
                    , particleEmitterTransform.position.z));
            }

        }
    }
}
