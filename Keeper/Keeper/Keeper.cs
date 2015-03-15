using Keeper.VisualControlers.Controls;
using Keeper.VisualControlers.Player;
using Keeper.VisualControlers.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Keeper
{
    public class Keeper : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Turret turret;
        Joystick leftStick;
        Joystick rightStick;
        Texture2D bulletTexture;
        List<Bullet> playerBullets = new List<Bullet>();
        TimeSpan playerShootTimer;

        public Keeper()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            player = new Player();
            turret = new Turret();
            leftStick = new Joystick();
            rightStick = new Joystick();
            playerShootTimer = TimeSpan.Zero;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);

            float joyStickY = GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height - 500;
            Vector2 leftJoystickPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, joyStickY);
            Vector2 rightJoystickPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + GraphicsDevice.Viewport.TitleSafeArea.Width - 500, joyStickY);

            player.Initialize(Content.Load<Texture2D>("Graphics\\player"), playerPosition);
            turret.Initialize(Content.Load<Texture2D>("Graphics\\turret"), player.position);
            leftStick.Initialize(Content.Load<Texture2D>("Graphics\\joyStick"), leftJoystickPosition);
            rightStick.Initialize(Content.Load<Texture2D>("Graphics\\joyStick"), rightJoystickPosition);
            bulletTexture = Content.Load<Texture2D>("Graphics\\bullet");
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            leftStick.Update(gameTime);
            rightStick.Update(gameTime);
            player.Update(gameTime, leftStick.rotationOutput, leftStick.length);
            turret.Update(gameTime, player.position, rightStick.rotationOutput, rightStick.length > 0);
            if (rightStick.length > 0) {
                playerShootTimer += gameTime.ElapsedGameTime;
                if (playerShootTimer > TimeSpan.FromSeconds(.3)) {
                    playerShootTimer = TimeSpan.Zero;
                    Bullet bullet = new Bullet();
                    bullet.Initialize(bulletTexture, player.position, rightStick.rotationOutput, 5f);
                    playerBullets.Add(bullet);
                }
            }
            foreach (Bullet bullet in playerBullets) { 
                bullet.Update(gameTime, GraphicsDevice.Viewport.Bounds); 
            }
            playerBullets.RemoveAll(x => !x.active);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            foreach (Bullet bullet in playerBullets) { 
                bullet.Draw(spriteBatch); 
            }
            turret.Draw(spriteBatch);

            leftStick.Draw(spriteBatch);
            rightStick.Draw(spriteBatch);
            spriteBatch.End(); 
            base.Draw(gameTime);
        }
    }
}
