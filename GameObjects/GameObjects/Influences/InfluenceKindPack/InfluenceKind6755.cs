﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6755 : InfluenceKind
    {
        private int increment;
        private int prob;

        public override void ApplyInfluenceKind(Troop t)
        {
            t.ReputationIncrease.Add(new System.Collections.Generic.KeyValuePair<int, int>(prob, increment));
        }

        public override void PurifyInfluenceKind(Troop t)
        {
            t.ReputationIncrease.Remove(new System.Collections.Generic.KeyValuePair<int, int>(prob, increment));
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.prob = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void InitializeParameter2(string parameter)
        {
            try
            {
                this.increment = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

