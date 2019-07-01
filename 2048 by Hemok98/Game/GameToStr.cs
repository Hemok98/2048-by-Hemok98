using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_by_Hemok98
{
    partial class Game
    {
        public string SaveGame()
        {
            string final = "";

            final += this.cellsCount.ToString() + ";";
            for (int i = 0; i < this.cellsCount; i++)
            {
                for (int j = 0; j < this.cellsCount; j++)
                {
                    final += this.cellsContainer[i, j].num.ToString() + ";";
                    final += this.copyCellsContainer[i, j].num.ToString() + ";";
                }
            }

            final += this.steps.ToString() + ";";
            final += this.score.ToString() + ";";
            final += this.canUseSkill.ToString() + ";";
            final += this.activatedSkill + ";";
            final += this.skillActivated.ToString() + ";";

            for (int i = 0; i < Skill.skillCount; i++)
            {
                final += this.skills[i].GetPrice().ToString() + ";" ;
            }

            final += swapCords[0] + ";" + swapCords[1] + ";";

                return final;
        }

        public void LoadGame(string str)
        {
            string parse = "";
            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.cellsCount = int.Parse(parse);
            this.cellsContainer = new Cells[this.cellsCount, this.cellsCount];
            this.copyCellsContainer = new Cells[this.cellsCount, this.cellsCount];

            for (int i = 0; i < this.cellsCount; i++)
            {
                for (int j = 0; j < this.cellsCount; j++)
                {
                    parse = str.Substring(0, str.IndexOf(";"));
                    str = str.Substring(str.IndexOf(";") + 1);
                    this.cellsContainer[i, j] = new Cells(int.Parse(parse));

                    parse = str.Substring(0, str.IndexOf(";"));
                    str = str.Substring(str.IndexOf(";") + 1);
                    this.copyCellsContainer[i, j] = new Cells(int.Parse(parse));
                }
            }

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.steps = int.Parse(parse);

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.record = int.Parse(parse);

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.canUseSkill = bool.Parse(parse);

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.activatedSkill = (SkillName)Enum.Parse(typeof(SkillName), parse);

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.skillActivated = bool.Parse(parse);

            for (int i = 0; i < Skill.skillCount; i++)
            {
                parse = str.Substring(0, str.IndexOf(";"));
                str = str.Substring(str.IndexOf(";") + 1);
                this.skills[i].SetPrice(int.Parse(parse));
            }

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.swapCords[0] = int.Parse(parse);

            parse = str.Substring(0, str.IndexOf(";"));
            str = str.Substring(str.IndexOf(";") + 1);
            this.swapCords[1] = int.Parse(parse);

        }
    }
}
