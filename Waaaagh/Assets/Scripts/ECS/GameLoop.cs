using System;
using System.Collections.Generic;
using Svelto.Context;
using Svelto.ECS;
using Svelto.ECS.Schedulers;
using Svelto.ECS.Schema.Definition;
using UnityEngine;

namespace Cathei.Waaagh
{
    public class GameLoop : MonoBehaviour, IDisposable
    {
        private SimpleEntitiesSubmissionScheduler _submissionScheduler;
        private TickEnginesGroup _tickEngines;

        public void Update()
        {
            _submissionScheduler.SubmitEntities();
            _tickEngines.Step(Time.deltaTime);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }

        public static GameLoop Create(
            SimpleEntitiesSubmissionScheduler submissionScheduler, TickEnginesGroup tickEngines)
        {
            var gameObject = new GameObject("GameLoop");
            DontDestroyOnLoad(gameObject);

            var gameLoop = gameObject.AddComponent<GameLoop>();
            gameLoop._submissionScheduler = submissionScheduler;
            gameLoop._tickEngines = tickEngines;

            return gameLoop;
        }
    }
}
