﻿namespace GameObjects.PersonDetail
{
    using GameObjects;
    using GameObjects.Conditions;
    using GameObjects.Influences;
    using GameObjects.TroopDetail;
    using System;

    public class Title : GameObject
    {
        private bool combat;
        public ConditionTable Conditions = new ConditionTable();
        public InfluenceTable Influences = new InfluenceTable();
        private TitleKind kind;
        private int level;

        private bool? containsLeaderOnlyCache = null;
        public bool ContainsLeaderOnly
        {
            get
            {
                if (containsLeaderOnlyCache != null)
                {
                    return containsLeaderOnlyCache.Value;
                }
                foreach (Influence i in this.Influences.Influences.Values)
                {
                    if (i.Kind.ID == 281)
                    {
                        containsLeaderOnlyCache = true;
                        return true;
                    }
                }
                containsLeaderOnlyCache = false;
                return false;
            }
        }

        public MilitaryType MilitaryTypeOnly
        {
            get
            {
                foreach (Influence i in this.Influences.Influences.Values)
                {
                    if (i.Kind.ID == 290)
                    {
                        return (MilitaryType)Enum.Parse(typeof(MilitaryType), i.Parameter);
                    }
                }
                return MilitaryType.其他;
            }
        }

        public void AddInfluence(Influence influence)
        {
            this.Influences.AddInfluence(influence);
        }

        public virtual bool CanLearn(Person person)
        {
            foreach (Condition condition in this.Conditions.Conditions.Values)
            {
                if (!condition.CheckCondition(person))
                {
                    return false;
                }
            }
            return true;
        }

        public GameObjectList GetConditionList()
        {
            return this.Conditions.GetConditionList();
        }

        public GameObjectList GetInfluenceList()
        {
            return this.Influences.GetInfluenceList();
        }

        public bool Combat
        {
            get
            {
                return this.combat;
            }
            set
            {
                this.combat = value;
            }
        }

        public int ConditionCount
        {
            get
            {
                return this.Conditions.Count;
            }
        }

        public string Description
        {
            get
            {
                string str = "";
                foreach (Influence influence in this.Influences.Influences.Values)
                {
                    str = str + "•" + influence.Description;
                }
                return str;
            }
        }

        public int InfluenceCount
        {
            get
            {
                return this.Influences.Count;
            }
        }

        public TitleKind Kind
        {
            get
            {
                return this.kind;
            }
            set
            {
                this.kind = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }

        public int Merit
        {
            get
            {
                return (int) (Math.Pow(this.level, 1.5) * 15);
            }
        }

        private int? fightingMerit = null;
        public int FightingMerit
        {
            get
            {
                if (fightingMerit == null)
                {
                    int combatInfluences = 0;
                    foreach (Influence i in this.Influences.Influences.Values)
                    {
                        if (i.Kind.Combat)
                        {
                            combatInfluences++;
                        }
                    }
                    fightingMerit = (int) (this.Merit * ((double)combatInfluences / this.Influences.Count));
                }
                return fightingMerit.Value;
            }
        }

        public string Prerequisite
        {
            get
            {
                string str = "";
                foreach (Condition condition in this.Conditions.Conditions.Values)
                {
                    str = str + "•" + condition.Name;
                }
                return str;
            }
        }
    }
}

