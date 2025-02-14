using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MapSystemSprint_Owen
{
    /// <summary>
    /// The game entity script for creating the player 
    /// and later for creating the enemies as of writing this.
    /// </summary>
    internal class GameEntity
    {
        private Vector2 position;
        protected Vector2 movementDirection;
        private Texture2D sprite;
        private Rectangle collider;
        private GameManager gameManager;

        public virtual void Update(float deltaTime)
        {
            position += movementDirection * deltaTime;
            //collider = new Rectangle;
        }

        public void Draw()
        {
            //gameManager.SpriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, 10, 10));
        }

    }
}