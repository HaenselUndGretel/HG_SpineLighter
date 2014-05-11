using KryptonEngine.Entities;
using KryptonEngine.SceneManagement;
using KryptonEngine.Pools;
using KryptonEngine.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HG_SpineLighter
{
    class GameScene : Scene
    {

        #region Propertie
        private SpineObject spineTest;
        private Texture2D normalMap;
        private Texture2D diffuseMap;
        private Effect test;
        #endregion

        public GameScene(string pSceneName)
            :base(pSceneName)
        {
            
        }

        public override void LoadContent()
        {
           test= KryptonEngine.EngineSettings.Content.Load<Effect>("testShader");
           normalMap = KryptonEngine.Manager.TextureManager.Instance.GetElementByString("fluffy-1-normal");
           diffuseMap = KryptonEngine.Manager.TextureManager.Instance.GetElementByString("fluffy-1-ch");
        }

        public override void Update()
        {
            spineTest.Update();
        }

        public override void Initialize()
        {
            mCamera = new Camera();

            spineTest = SpinePool.Fluffy.GetObject();
            spineTest.SetPosition(mCamera.GetTranslationMatrix(), new Vector2(300, 500));
            spineTest.AnimationState.SetAnimation(0, "idle", true);
            spineTest.cShader = test;
            spineTest.normalMap = normalMap;
            spineTest.chMap = diffuseMap;
        }

        public override void Draw()
        {
            KryptonEngine.EngineSettings.Graphics.GraphicsDevice.Clear(new Color(25, 19, 23));

           spineTest.Draw(mSpriteBatch);
        }
    }
}
