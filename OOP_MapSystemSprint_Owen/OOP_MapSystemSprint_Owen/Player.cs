using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MapSystemSprint_Owen
{
    internal class Player : GameEntity
    {
        private Texture2D texture;
        private Rectangle collider;
        private SpriteBatch spriteBatch;
        private Vector2 position;

        public float speed = 2f;

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.X += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.Y += speed;
            }
        }



    }
}
