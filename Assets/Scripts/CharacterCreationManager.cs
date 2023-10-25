using System.Collections.Generic;
using UnityEngine;

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

        // Initialize default values for player attributes
        public void InitializeDefaultValues()
        {
            PlayerSex = Sex.Male;
            PlayerGender = Gender.Male;
            PlayerRace = Race.Human;
            PlayerWeight = 70f;
            PlayerHeight = 1.8f;
            PlayerEyeColor = "Blue";
            PlayerHairColor = "Black";
            PlayerAge = 25;
            StartingLocation = "City";
            PlayerJob = Job.None;
            PlayerSkills.Clear();
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

        public bool ValidatePlayerAttributes()
        {
            if (PlayerAge < 18 || PlayerAge > 100)
            {
                return false;
            }

            if (PlayerWeight < 30 || PlayerWeight > 200)
            {
                return false;
            }

            if (PlayerHeight < 1.2f || PlayerHeight > 2.2f)
            {
                return false;
            }

            if (PlayerSkills.Count == 0)
            {
                return false;
            }

            // TODO: Add more complex validation logic based on the game's requirements
            // Example: Validate that the player's skills match their job
            if (PlayerJob == Job.Doctor && !PlayerSkills.Contains("First Aid"))
            {
                return false;
            }

            return true;
        }
    }