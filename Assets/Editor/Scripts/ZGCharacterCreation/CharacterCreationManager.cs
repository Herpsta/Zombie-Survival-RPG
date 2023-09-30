using System.Collections.Generic;

namespace ZGCharacterCreation
{
    public class CharacterCreationManager
    {
        public Sex PlayerSex { get; set; }
        public Gender PlayerGender { get; set; }
        public Race PlayerRace { get; set; }
        public float PlayerWeight { get; set; }
        public float PlayerHeight { get; set; }
        public string PlayerEyeColor { get; set; }
        public string PlayerHairColor { get; set; }
        public int PlayerAge { get; set; }
        public string StartingLocation { get; set; }
        public Job PlayerJob { get; set; }
        public List<string> PlayerSkills { get; set; }

        public CharacterCreationManager()
        {
            PlayerSkills = new List<string>();
        }

        public void SetPlayerSkillsBasedOnJob()
        {
            switch (PlayerJob)
            {
                case Job.Doctor:
                    PlayerSkills.Add("First Aid");
                    PlayerSkills.Add("Surgery");
                    break;
                case Job.Engineer:
                    PlayerSkills.Add("Mechanics");
                    PlayerSkills.Add("Electronics");
                    break;
                case Job.Teacher:
                    PlayerSkills.Add("Education");
                    PlayerSkills.Add("Communication");
                    break;
                case Job.Police:
                    PlayerSkills.Add("Firearms");
                    PlayerSkills.Add("Law");
                    break;
                case Job.Firefighter:
                    PlayerSkills.Add("Firefighting");
                    PlayerSkills.Add("Rescue");
                    break;
                case Job.Other:
                    PlayerSkills.Add("Custom Skill 1");
                    PlayerSkills.Add("Custom Skill 2");
                    break;
            }
        }
    }
}
