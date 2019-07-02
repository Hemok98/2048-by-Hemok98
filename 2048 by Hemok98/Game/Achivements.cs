using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_by_Hemok98
{
    [Serializable]
    class Achievements
    {
        public static int achivCount = 19;
        private bool[] achivContainer = new bool[achivCount];

        private int[] skillsCount = new int[Skill.skillCount];

        public Achievements()
        {
            for (int i = 0; i < achivCount; i++)
            {
                this.achivContainer[i] = false;
            }

            for (int i = 0; i < Skill.skillCount; i++)
            {
                this.skillsCount[i] = 0;
            }

        }

        public void ChekGame(Game game)
        {
            int record = 0, steps = 0, score = 0;
            int[,] cells = new int[game.cellsCount, game.cellsCount];
            game.GetGame(cells, ref record, ref score, ref steps);

            for (int i  = 0; i < game.cellsCount; i++)
            {
                for (int j = 0; j < game.cellsCount; j++)
                {
                    this.achivContainer[0] = this.achivContainer[0] || (cells[i, j] == 256);
                    this.achivContainer[1] = this.achivContainer[1] || (cells[i, j] == 512);
                    this.achivContainer[2] = this.achivContainer[2] || (cells[i, j] == 1024);
                    this.achivContainer[3] = this.achivContainer[3] || (cells[i, j] == 2048);
                    this.achivContainer[4] = this.achivContainer[4] || (cells[i, j] == 4096);
                }
            }

            this.achivContainer[5] = this.achivContainer[5] || (record > 1000);
            this.achivContainer[6] = this.achivContainer[6] || (record > 5000);
            this.achivContainer[7] = this.achivContainer[7] || (record > 10000);
            this.achivContainer[8] = this.achivContainer[8] || (record > 50000);
        }

        public void ChekSkill(SkillName name)
        {
            this.achivContainer[9] = this.achivContainer[9] || (name == SkillName.X2);
            this.achivContainer[10] = this.achivContainer[10] || (name == SkillName.DELETE);
            this.achivContainer[11] = this.achivContainer[11] || (name == SkillName.BACK);
            this.achivContainer[12] = this.achivContainer[12] || (name == SkillName.SWAP);

            if (name == SkillName.X2) skillsCount[0]++;
            if (name == SkillName.DELETE) skillsCount[1]++;
            if (name == SkillName.BACK) skillsCount[2]++;
            if (name == SkillName.SWAP) skillsCount[3]++;

            for (int i = 0; i < Skill.skillCount; i++)
            {
                if (skillsCount[0] >= 5) this.achivContainer[13+i] = true;
            }

        }

        public void ChekSaveLoad(string chek)
        {
            if (chek == "save") achivContainer[17] = true;
            if (chek == "load") achivContainer[18] = true;
        }

        public void LoadAchivements(string str)
        {
            string parse = "";
            for (int i = 0; i < Achievements.achivCount; i++)
            {
                parse = str.Substring(0, str.IndexOf(";"));
                str = str.Substring(str.IndexOf(";") + 1);
                this.achivContainer[i] = bool.Parse(parse);
            }

            for (int i = 0; i < Skill.skillCount; i++)
            {
                parse = str.Substring(0, str.IndexOf(";"));
                str = str.Substring(str.IndexOf(";") + 1);
                this.skillsCount[i] = int.Parse(parse);
            }
        }

        public string SaveGame()
        {
            string final = "";
            for (int i = 0; i < Achievements.achivCount; i++)
            {
                final += this.achivContainer[i].ToString()+";";
            }

            for (int i = 0; i < Skill.skillCount; i++)
            {
                final += this.skillsCount[i].ToString() + ";";
            }

            return final;
        }

        public bool GetAchivement(int num)
        {
            if (num >= Achievements.achivCount) return false;
            if (num < 0) return false;
            return achivContainer[num];
        }
    }
}
