﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksEditor {
    class Stage {
        const int BRICK_W = 80;
        const int BRICK_H = 30;
        const int BRICK_X_INT = 90;
        const int BRICK_Y_INT = 40;
        const int BRICK_X_COUNT = 8;
        const int BRICK_Y_COUNT = 6;
        const int BRICK_X_OFFSET = 30;
        const int BRICK_Y_OFFSET = 80;
        //const int WINDOW_WIDTH = GameForm.WIDTH;
        //const int WINDOW_HEIGHT = GameForm.HEIGHT;

        public List<Brick> bricks = new List<Brick>();
        private int stageNumber;

        public Stage(int stageNumber) 
            : this("./stage_0" + stageNumber + ".txt")
        { }


        public Stage(string fileName)
        {
            try {
                StreamReader reader = new StreamReader(fileName);
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    string[] numbers = line.Split(',');
                    if (numbers.Length < 5) {
                        continue;
                    }
                    int x = int.Parse(numbers[0]);
                    int y = int.Parse(numbers[1]);
                    int w = int.Parse(numbers[2]);
                    int h = int.Parse(numbers[3]);
                    int t = int.Parse(numbers[4]);
                    Brick brick = new Brick(w, h);
                    brick.setPosition(x, y);
                    brick.type = t;
                    bricks.Add(brick);
                }
            } catch (Exception e) {
                System.Diagnostics.Debug.Print(e.ToString());
            }
        }

        public void draw(Graphics g)
        {
            foreach (Brick brick in bricks) {
                brick.draw(g);
            }
        }

        //internal void checkCollision(Ball ball)
        //{
        //    foreach (Brick brick in bricks) {
        //        if (ball.didBounce(brick)) {
        //            bricks.Remove(brick);
        //            break;
        //        }
        //    }
        //}
    }
}
