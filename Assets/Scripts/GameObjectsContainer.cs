using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class GameObjectsContainer
    {

        public Dictionary<string, GameObject> container = new Dictionary<string, GameObject>();


        static GameObjectsContainer instance;
        public static GameObjectsContainer Instance
        {
            get
            {
                if (instance == null)
                    return new GameObjectsContainer();
                else
                    return instance;
            }
            
        }


        public GameObjectsContainer()
        {
            instance = this;
        }
    }

}

