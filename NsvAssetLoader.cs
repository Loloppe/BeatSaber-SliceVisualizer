using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Zenject;

namespace SliceVisualizer
{
    internal class NsvAssetLoader : IInitializable, IDisposable
    {
        private Material? _uiNoGlowMaterial;
        private bool _loggedNoGlowMaterial = false;

        public Material? UINoGlowMaterial {
            get {
                if (!(_uiNoGlowMaterial is null))
                {
                    return _uiNoGlowMaterial;
                }
                var sprite = Resources.FindObjectsOfTypeAll<Material>().FirstOrDefault(m => m.name == "NoGlowNoFogSprite");
                if (sprite is null)
                {
                    if (!_loggedNoGlowMaterial)
                    {
                        _loggedNoGlowMaterial = true;
                    }
                    return null;
                }

                _uiNoGlowMaterial = new Material(sprite);
                return _uiNoGlowMaterial;
            }
        }

        public Sprite? RRect { get; private set; }
        public Sprite? Circle { get; private set; }
        public Sprite? Arrow { get; private set; }
        public Sprite? White { get; private set; }

        public NsvAssetLoader()
        {
            Initialize();
        }

        public void Initialize()
        {
            var assembly = Assembly.GetExecutingAssembly();
            RRect = LoadSpriteFromResources(assembly, "SliceVisualizer.Assets.RRect.png");
            Circle = LoadSpriteFromResources(assembly, "SliceVisualizer.Assets.Circle.png");
            Arrow = LoadSpriteFromResources(assembly, "SliceVisualizer.Assets.Arrow.png");
            White = LoadSpriteFromResources(assembly, "SliceVisualizer.Assets.White.png", 1f);
        }

        public void Dispose()
        {
            _uiNoGlowMaterial = null;

            RRect = null;
            Circle = null;
            Arrow = null;
            White = null;
        }

        private Sprite? LoadSpriteFromResources(Assembly assembly, string resourcePath, float pixelsPerUnit = 256.0f)
        {
            using var stream = assembly.GetManifestResourceStream(resourcePath);
            if (stream == null)
            {
                return null;
            }

            byte[] imageData = new byte[stream.Length];
            stream.Read(imageData, 0, (int) stream.Length);
            if (imageData.Length == 0)
            {
                return null;
            }

            var texture = new Texture2D(2, 2, TextureFormat.RGBA32, false, false);
            texture.LoadImage(imageData);

            var rect = new Rect(0, 0, texture.width, texture.height);
            var sprite = Sprite.Create(texture, rect, Vector2.zero, pixelsPerUnit);

            return sprite;
        }
    }
}