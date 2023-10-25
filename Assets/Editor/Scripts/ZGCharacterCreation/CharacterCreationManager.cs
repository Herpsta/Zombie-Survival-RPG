using System.Collections.Generic;
using UnityEngine;

namespace ZGCharacterCreation
{
    public class CharacterCreationManager : MonoBehaviour
    {
        [Tooltip("Player's sex")]
        public Sex PlayerSex { get; set; }

        [Tooltip("Player's gender")]
        public Gender PlayerGender { get; set; }

        [Tooltip("Player's race")]
        public Race PlayerRace { get; set; }

        [Tooltip("Player's weight")]
        public float PlayerWeight { get; set; }

        [Tooltip("Player's height")]
        public float PlayerHeight { get; set; }

        [Tooltip("Player's eye color")]
        public string PlayerEyeColor { get; set; }

        [Tooltip("Player's hair color")]
        public string PlayerHairColor { get; set; }

        [Tooltip("Player's age")]
        public int PlayerAge { get; set; }

        [Tooltip("Starting location")]
        public string StartingLocation { get; set; }

        [Tooltip("Player's job")]
        public Job PlayerJob { get; set; }

        [Tooltip("Player's skills")]
        public List<string> PlayerSkills { get; set; }

        public CharacterCreationManager()
        {
            PlayerSkills = new List<string>();
        }

        public void SetPlayerSkillsBasedOnJob()
        {
            PlayerSkills.Clear();
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

        // Save character data to PlayerPrefs
        public void SaveCharacterData()
        {
            PlayerPrefs.SetString("PlayerSex", PlayerSex.ToString());
            PlayerPrefs.SetString("PlayerGender", PlayerGender.ToString());
            PlayerPrefs.SetString("PlayerRace", PlayerRace.ToString());
            PlayerPrefs.SetFloat("PlayerWeight", PlayerWeight);
            PlayerPrefs.SetFloat("PlayerHeight", PlayerHeight);
            PlayerPrefs.SetString("PlayerEyeColor", PlayerEyeColor);
            PlayerPrefs.SetString("PlayerHairColor", PlayerHairColor);
            PlayerPrefs.SetInt("PlayerAge", PlayerAge);
            PlayerPrefs.SetString("PlayerJob", PlayerJob.ToString());
            PlayerPrefs.SetString("PlayerSkills", string.Join(",", PlayerSkills));
            PlayerPrefs.Save();
        }

        // Load character data from PlayerPrefs
        public void LoadCharacterData()
        {
            PlayerSex = (Sex)System.Enum.Parse(typeof(Sex), PlayerPrefs.GetString("PlayerSex"));
            PlayerGender = (Gender)System.Enum.Parse(typeof(Gender), PlayerPrefs.GetString("PlayerGender"));
            PlayerRace = (Race)System.Enum.Parse(typeof(Race), PlayerPrefs.GetString("PlayerRace"));
            PlayerWeight = PlayerPrefs.GetFloat("PlayerWeight");
            PlayerHeight = PlayerPrefs.GetFloat("PlayerHeight");
            PlayerEyeColor = PlayerPrefs.GetString("PlayerEyeColor");
            PlayerHairColor = PlayerPrefs.GetString("PlayerHairColor");
            PlayerAge = PlayerPrefs.GetInt("PlayerAge");
            PlayerJob = (Job)System.Enum.Parse(typeof(Job), PlayerPrefs.GetString("PlayerJob"));
            PlayerSkills = new List<string>(PlayerPrefs.GetString("PlayerSkills").Split(','));
        }

        // Validate player attributes
        public bool ValidatePlayerAttributes()
        {
            // Add your validation logic here
            // For example, check if age is within a certain range
            if (PlayerAge < 18 || PlayerAge > 100)
            {
                return false;
            }

            // Check if weight is within a certain range
            if (PlayerWeight < 30 || PlayerWeight > 200)
            {
                return false;
            }

            // Check if height is within a certain range
            if (PlayerHeight < 1.2f || PlayerHeight > 2.2f)
            {
                return false;
            }

            // Check if skills are not empty
            if (PlayerSkills.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}