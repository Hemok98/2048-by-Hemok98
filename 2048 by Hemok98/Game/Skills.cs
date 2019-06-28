using System;
using System.IO;

namespace _2048_by_Hemok98
{
    [Serializable]
    class Skill
    {
        private int startPrice;
        private int nowPrice;
        private SkillName name;
        public static bool canUseSkill = false;
        public static bool skillActivated = false;

        public static int skillCount = 4;

        public static SkillName activatedSkill;

        public Skill(int price, SkillName name)
        {
            this.startPrice = price;
            this.nowPrice = price;
            this.name = name;
        }

        public int GetPrice()
        {
            return this.nowPrice;
        }

        public SkillName GetName()
        {
            return this.name;
        }

        public void IncPrice()
        {
            this.nowPrice *= 5;
            this.nowPrice /= 4;
        }

        public void ResetPrice()
        {
            this.nowPrice = this.startPrice;
        }

        public static void SkillEnd()
        {
            Skill.canUseSkill = false;
            Skill.skillActivated = false;
        }
    }

    enum SkillName //перечисление : варианты скилов
    {
        X2, DELETE, BACK, SWAP
    }

}
