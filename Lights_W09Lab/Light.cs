using System;
using System.Collections.Generic;
//using System.Drawing;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using GeoSketch;

namespace Lights_W09Lab
{
    internal class Light
    {
        public Point CenterPoint { get; set; } //Version 1 Recommended

        private float _radius;
        public float Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }//property Version 2 recommended to use when data when we want to set outide the class. (change colour of the light, we have control when it happens, react to the color change. )


        //property Version 2 started
        private Color _color;
        public Color Color {
            get {  return _color; }    set   {_color = value; }
        }//property Version 2 recommended to use when data when we want to set outide the class. (change colour of the light, we have control when it happens, react to the color change. )

        public bool isOn {  get; set; }

        //Version1 started
        public Color GetColor()
        {
            return _color;
        }

      

        public void SetColor(Color value)
        {
            _color = value;
        }//Version 3 (not recommended)


        //propfull +2 times TAB = timeplate for property!!

        public Light(Point centerPoint, float radius, Color color) //constructor with empty list, can have parameters, forms to create light. Local varibles lower case. Publoc variables capital. 
        {
            CenterPoint = centerPoint;
            Radius = radius;
            Color = color;
            isOn = false;

        }

        public Light(Point centerPoint, Color color): this(centerPoint, 30f, color) //Constructor can pass code to another constructor. (: this(call the other constructor)
        {
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Color colorToDraw = Color.Gray;
            //if (isOn)
            //{
            //    colorToDraw = Color;
            //}
            Color colorToDraw = isOn ? _color : Color.Gray; 
            
            spriteBatch.DrawCircle(CenterPoint.X, CenterPoint.Y, (int)Radius, colorToDraw, colorToDraw, 0);  
        }

        private bool isMouseOnTop (int mouseX, int mouseY)
        {
            //Canculate the center of the circle, get radius. mouse position is >than mouse position, or <=. 
            int dx = mouseX - CenterPoint.X; //katet of triangle 
            int dy = mouseY - CenterPoint.Y;//katet of triangle , to have a distance need to find a hepotenuse. c^2=b^2+a^2
            //dist = sqrt(dx^2 + dy^2)
            float distanceSquared = /*MathF.Sqrt */ (dx *dx + dy * dy); //square root = MathF.Sqrt(of)/ might sslow down the game, if use it a lot, takes a lot of data and does a lot of calculations. 

            if (distanceSquared <= Radius * Radius) //Radius * Radius instead of MathF.Sqrt for better performance. 
            {
                return true;
            }
            else
            {
                return false;
            }
            //TODO: figure this out
            return true;
        }

        public void ToggleLightWithMouse (int mouseX, int mouseY)
        {
            if (isMouseOnTop(mouseX,mouseY))
            {
                isOn = !isOn; //isOn = isOn == false;
            }
        }
    }
}
