﻿using System.Collections.Generic;

namespace LedGeekBox.Model.Scenario
{

    public interface IStep
    {
        void Apply(List< bool[,]> datas , bool firstline);
    }

    public interface IScenario
    {
        int Start(List<IStep> steps);
        void Stop();
    }
}