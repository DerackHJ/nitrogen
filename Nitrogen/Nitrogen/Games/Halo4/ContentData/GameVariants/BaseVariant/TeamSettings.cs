﻿/*
 *   Nitrogen - Halo Content API
 *   Copyright © 2013 The Nitrogen Authors. All rights reserved.
 * 
 *   This file is part of Nitrogen.
 *
 *   Nitrogen is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   Nitrogen is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with Nitrogen.  If not, see <http://www.gnu.org/licenses/>.
 */

using Nitrogen.ContentData.Localization;
using Nitrogen.IO;
using System;
using System.Diagnostics.Contracts;
using System.Drawing;

namespace Nitrogen.Games.Halo4.ContentData.GameVariants.BaseVariant
{
    /// <summary>
    /// Represents a set of team properties in a Halo 4 multiplayer variant.
    /// </summary>
    public class TeamSettings
        : ISerializable<BitStream>
    {
        public const int MaxTeams = 8;

        private byte teamModelOverride, designatorSwitchType;
        private TeamData[] teams;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamSettings"/> class with default values.
        /// </summary>
        public TeamSettings()
        {
            this.teams = new TeamData[MaxTeams];
            for (int i = 0; i < MaxTeams; i++)
                this.teams[i] = new TeamData();
        }

        public TeamData this[int index]
        {
            get { return this.teams[index]; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                this.teams[index] = value;
            }
        }

        public TeamData[] GetTeams()
        {
            return this.teams;
        }

        #region ISerializable<BitStream>

        public void Serialize(BitStream s)
        {
            s.Stream(ref this.teamModelOverride, 3);
            s.Stream(ref this.designatorSwitchType, 2);
            s.Serialize(this.teams, 0, MaxTeams);
        }

        #endregion
    }
}