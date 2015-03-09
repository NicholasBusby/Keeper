using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.VisualControlers.Player {
    class Player {

        public Texture2D texture { get; set; }
        public Vector2 position { get; set; }
        public bool active { get; set; }
        private float rotation = 0f;
        private double speed = 0;

        public void Initialize(Texture2D texture, Vector2 position) {
            this.position = position;
            this.texture = texture;
            this.active = true;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, Vector2.Zero, 1f,
               SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime, float movementAngle, float movementSpeed, float shootAngle) {
            if (movementSpeed > 0) {
                rotation = movementAngle;
                speed = movementSpeed;
                Vector2 movement = angleToVector(movementAngle);
                //movement = Vector2.Multiply(movement, movementSpeed);
                position = Vector2.Add(position, movement);
            } else {
                movementSpeed = 0;
            }
        }

        private Vector2 angleToVector(float angle) {
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }
    }
}
