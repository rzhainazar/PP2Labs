﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    [Serializable]
    class HighScores
    {
        public List<string> name;
        public List<int> score;
        public HighScores()
        {
            name = new List<string>();
            score = new List<int>();
        }
    }
}
