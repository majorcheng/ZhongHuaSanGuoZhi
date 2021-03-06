﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind3030 : InfluenceKind
    {
        private float rate = 0f;

        public override void ApplyInfluenceKind(Architecture architecture)
        {
            architecture.RateIncrementOfMonthFood += this.rate;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.rate = float.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Architecture architecture)
        {
            architecture.RateIncrementOfMonthFood -= this.rate;
        }

        public override double AIFacilityValue(Architecture a)
        {
            return (1 - Math.Pow((double)a.Food / a.FoodCeiling, 0.5) + (a.IsFoodEnough ? 0 : 0.5) + (a.IsFoodAbundant ? 0 : 0.5))
                * (a.ExpectedFood * this.rate / 20000.0);
        }
    }
}

