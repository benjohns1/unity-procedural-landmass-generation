﻿using UnityEngine;

namespace NoiseGenerator.Filters
{
    public class Constant : IFilter
    {
        private FilterSettings.Constant settings;

        public Constant(FilterSettings.Constant settings)
        {
            this.settings = settings;
        }

        public void Setup(float globalMin, float globalMax)
        {
        }

        public float GetMin()
        {
            return settings.value;
        }

        public float GetMax()
        {
            return settings.value;
        }

        public void StartNewRegion(int width, int height)
        {
        }

        public float Evaluate(Vector2 point)
        {
            return settings.value;
        }
    }
}