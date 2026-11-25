using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public enum GameSceneCategory
    {
        Title,
        Gameplay,
    }
    public class SceneNavigator
    {
        private IView _currentScene;
        private readonly Dictionary<GameSceneCategory, IView> _sceneViewDict;
        private readonly IFader _screenFader;

        public SceneNavigator(
            Dictionary<GameSceneCategory, IView> sceneViewDict, 
            IFader screenFader)
        {
            _screenFader = screenFader;
            _sceneViewDict = sceneViewDict;
            foreach (var pair in sceneViewDict)
            {
                pair.Value.Hide();
            }
        }
        public void Register(GameSceneCategory gameScene, IView scene)
        {
            _sceneViewDict[gameScene] = scene;
        }
        public async ValueTask NavigateToAsync(GameSceneCategory gameScene, Action onSceneChanging = null)
        {
            IView sceneView = _sceneViewDict[gameScene];
            await _screenFader.FadeOutAsync();
            _currentScene?.Hide();
            onSceneChanging?.Invoke();
            _currentScene = sceneView;
            _currentScene.Show();
            await _screenFader.FadeInAsync();
        }
    }
}
