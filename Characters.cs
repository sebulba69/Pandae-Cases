using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae
{
    /// <summary>
    /// Character presets for dialog.
    /// </summary>
    public class Characters
    {
        // string = Name, character = Character
        private Dictionary<string, Character> characters = new Dictionary<string, Character>();

        public Characters()
        {
            MakePandae();
            MakeSmirkfred();
        }

        public Character GetCharacter(string name)
        {
            return characters[name];
        }

        private void MakePandae()
        {
            Character character = new Character() 
            {
                Name = Globals.Pandae,
                Blips = Blips.Male
            };

            characters.Add(character.Name, character);
        }

        private void MakeSmirkfred()
        {
            Character character = new Character()
            {
                Name = Globals.Smirkfred,
                Blips = Blips.Male
            };

            characters.Add(character.Name, character);
        }
    }
}
