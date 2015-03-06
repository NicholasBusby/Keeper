using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.VisualControlers.Player {
    class Player : IVisualControl {
                                            //this is just a test to make sure I am not an idiot
        public Texture2D texture { get; set; }
        public Vector2 position { get; set; }
        public bool active { get; set; }

        public void Initialize(Microsoft.Xna.Framework.Graphics.Texture2D texture, Microsoft.Xna.Framework.Vector2 position) {
            this.position = position;
            this.texture = texture;
            this.active = true;
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f,
               SpriteEffects.None, 0f);
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime) {
            
        }
    }
}
