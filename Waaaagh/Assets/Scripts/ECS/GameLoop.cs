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
        private TickableEnginesGroup _tickables;

        public void Update()
        {
            _submissionScheduler.SubmitEntities();
            _tickables.Step(Time.deltaTime);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }

        public static GameLoop Create(
            SimpleEntitiesSubmissionScheduler submissionScheduler, TickableEnginesGroup tickables)
        {
            var gameObject = new GameObject("GameLoop");
            DontDestroyOnLoad(gameObject);

            var gameLoop = gameObject.AddComponent<GameLoop>();
            gameLoop._submissionScheduler = submissionScheduler;
            gameLoop._tickables = tickables;

            return gameLoop;
        }
    }
}
