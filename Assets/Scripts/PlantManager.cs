using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlantManager : MonoBehaviour
    {

        public List<Plant> plantTypes;

        public GameObject plantTypesGameObject;

        public PlantManager Instance;
        // Use this for initialization
        void Start()
        {
            plantTypes = GetPlantTypes();

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Awake()
        {
            Instance = this;
        }

        private List<Plant> GetPlantTypes() { 
            return plantTypesGameObject.GetComponentsInChildren<Plant>().OrderBy(plant => plant.level).ToList();
        }

        public Plant GetPlantType(Tiles.Type type)
        {
            return plantTypes.FirstOrDefault(plant => plant.Type == type);
        }

    }
}