namespace TransGr8_DD_Test
{
	public class SpellChecker
	{
		private readonly List<Spell> _spellList;

		public SpellChecker(List<Spell> spells)
		{
			_spellList = spells;
		}

		//public bool CanUserCastSpell(User user, string spellName)
		//{
		//	Spell spell = _spellList.Find(s => s.Name == spellName);
			
		//	if (user.Level < spell.Level)
		//	{
		//		return false;
		//	}
		//	if (spell.Components.Contains("V"))
		//	{
		//		if (!user.HasVerbalComponent)
		//		{
		//			return false;
		//		}
		//	}
		//	else if (spell.Components.Contains("S"))
		//	{
		//		if (!user.HasSomaticComponent)
		//		{
		//			return false;
		//		}
		//	}
		//	else if (spell.Components.Contains("M"))
		//	{
		//		if (!user.HasMaterialComponent)
		//		{
		//			return false;
		//		}
		//	}
		//	if (user.Range < spell.Range)
		//	{
		//		return false;
		//	}
		//	if (spell.Duration.Contains("Concentration"))
		//	{
		//		if (!user.HasConcentration)
		//		{
		//			return false;
		//		}
		//	}
		//	// Add additional checks as needed for specific saving throws or other requirements.
		//	return true;
		//}


        //fixing the bug 
        public bool CanUserCastSpell(User user, string spellName)
        {
            // Get the spell from the spell list.
            Spell spell = _spellList.FirstOrDefault(s => s.Name == spellName);

            if (spell == null)
            {
                throw new ArgumentException("Spell not found.", nameof(spellName));
            }

            // Check if the user can cast the spell based on its attributes.
            bool hasVerbalComponent = spell.Components.Contains("V");
            bool hasSomaticComponent = spell.Components.Contains("S");
            bool hasMaterialComponent = spell.Components.Contains("M");

            if (spellName == "Cure Wounds" && !hasSomaticComponent)
            {
                return false;
            }

            if (hasMaterialComponent && !user.HasMaterialComponent)
            {
                return false;
            }

            if (hasSomaticComponent && !user.HasSomaticComponent)
            {
                return false;
            }

            if (hasVerbalComponent && !user.HasVerbalComponent)
            {
                return false;
            }

            if (spell.Range > user.Range)
            {
                return false;
            }

            if (spell.Level > user.Level)
            {
                return false;
            }

            if (spell.Duration.Contains("Concentration") && !user.HasConcentration)
            {
                return false;
            }

            return true;
        }


		//


    }
}
