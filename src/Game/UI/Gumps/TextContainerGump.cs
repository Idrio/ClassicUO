﻿#region license
// Copyright (C) 2020 ClassicUO Development Community on Github
// 
// This project is an alternative client for the game Ultima Online.
// The goal of this is to develop a lightweight client considering
// new technologies.
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.
#endregion
// #region license
// //  Copyright (C) 2020 ClassicUO Development Community on Github
// //
// // This project is an alternative client for the game Ultima Online.
// // The goal of this is to develop a lightweight client considering
// // new technologies.
// //
// //  This program is free software: you can redistribute it and/or modify
// //  it under the terms of the GNU General Public License as published by
// //  the Free Software Foundation, either version 3 of the License, or
// //  (at your option) any later version.
// //
// //  This program is distributed in the hope that it will be useful,
// //  but WITHOUT ANY WARRANTY; without even the implied warranty of
// //  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// //  GNU General Public License for more details.
// //
// //  You should have received a copy of the GNU General Public License
// //  along with this program.  If not, see <https://www.gnu.org/licenses/>.
// #endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassicUO.Game.GameObjects;
using ClassicUO.Game.Managers;
using ClassicUO.IO.Resources;
using ClassicUO.Renderer;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Mouse = ClassicUO.Input.Mouse;

namespace ClassicUO.Game.UI.Gumps
{
    abstract class TextContainerGump : Gump
    {
        protected TextContainerGump(uint local, uint server) : base(local, server)
        {

        }

        public TextRenderer TextRenderer { get; } = new TextRenderer();


        public void AddText(TextOverhead msg)
        {
            if (World.ClientFeatures.TooltipsEnabled || msg == null)
                return;

            msg.Time = Time.Ticks + 4000;
           
            TextRenderer.AddMessage(msg);
        }

        public override void Update(double totalMS, double frameMS)
        {
            base.Update(totalMS, frameMS);
            TextRenderer.Update(totalMS, frameMS);
        }

        public override void Dispose()
        {
            TextRenderer.Clear();
            base.Dispose();
        }


        public override bool Draw(UltimaBatcher2D batcher, int x, int y)
        {
            base.Draw(batcher, x, y);

            //TextRenderer.MoveToTopIfSelected();
            TextRenderer.ProcessWorldText(true);
            TextRenderer.Draw(batcher, x, y, -1, true);
            return true;
        }
    }
}
