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
        protected float targetDistanceFromPlayer = 130.0f;

        [SerializeField]
        protected float minimumDistance = 20.0f;

        protected Camera mainCamera;
        protected Transform playerTransform;

        

        void Start()
        {
            mainCamera = Camera.main;
            playerTransform = GameManager.instance.Player.GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            float distanceFromPlayer = transform.position.x - playerTransform.position.x;
            if (distanceFromPlayer < minimumDistance)
            {
                Vector3 newParticleEmitterPosition = new Vector3(playerTransform.position.x + targetDistanceFromPlayer
                    , transform.position.y
                    , transform.position.z);

                GameObject newRadarParticles = Instantiate(gameObject, newParticleEmitterPosition, Quaternion.identity) as GameObject;
                GameObject.Destroy(gameObject);
            }
        }
    }
}
