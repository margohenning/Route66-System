using System;
using System.Text.RegularExpressions;

namespace Utilities.SouthAfrica
{
	/// <summary>
	/// Represents a South African Identity Number.
	/// </summary>
	[Serializable()]
	public class IdentityNumber
	{

		#region Enumerations
		/// <summary>
		/// Indicates a gender.
		/// </summary>
		public enum PersonGender 
		{
			Female = 0,
			Male = 5
		}

		public enum PersonCitizenship 
		{
			SouthAfrican = 0,
			Foreign = 1
		}
		#endregion

		#region Declarations
		static Regex _expression;
		Match _match;
		const string _IDExpression = @"(?<Year>[0-9][0-9])(?<Month>([0][1-9])|([1][0-2]))(?<Day>([0-2][0-9])|([3][0-1]))(?<Gender>[0-9])(?<Series>[0-9]{3})(?<Citizenship>[0-9])(?<Uniform>[0-9])(?<Control>[0-9])";
		#endregion

		#region Constuctors
		/// <summary>
		/// Sets up the shared objects for ID validation.
		/// </summary>
		static IdentityNumber() 
		{
			_expression = new Regex(_IDExpression, RegexOptions.Compiled | RegexOptions.Singleline);
		}

		/// <summary>
		/// Creates the ID number from a string.
		/// </summary>
		/// <param name="IDNumber">The string ID number.</param>
		public IdentityNumber(string IDNumber)
		{
            if (IDNumber.Length == 13)
            {
                _match = _expression.Match(IDNumber.Trim());
            }
            else
            {
                _match = _expression.Match("0");
            }
			
		}
		#endregion

		#region Properties
		/// <summary>
		/// Indicates the date of birth encoded in the ID Number.
		/// </summary>
		/// <exception cref="System.ArgumentException">Thrown if the ID Number is not usable.</exception>
		public DateTime DateOfBirth 
		{
			get 
			{
				if(IsUsable == false) 
				{
					throw new ArgumentException("ID Number is unusable!", "IDNumber");
				}
				int year = int.Parse(_match.Groups["Year"].Value);

				// NOTE: Do not optimize by moving these to static, otherwise the calculation may be incorrect
				// over year changes, especially century changes.
				int currentCentury = int.Parse(DateTime.Now.Year.ToString().Substring(0, 2) + "00");
				int lastCentury = currentCentury - 100;
				int currentYear = int.Parse(DateTime.Now.Year.ToString().Substring(2, 2));

				// If the year is after or at the current YY, then add last century to it, otherwise add
				// this century.
				// TODO: YY -> YYYY logic needs thinking about
				if(year > currentYear) 
				{
					year += lastCentury;
				} 
				else 
				{
					year += currentCentury;
				}
				return new DateTime(year, int.Parse(_match.Groups["Month"].Value), int.Parse(_match.Groups["Day"].Value));
			}
		}

		/// <summary>
		/// Indicates the gender for the ID number.
		/// </summary>
		/// <exception cref="System.ArgumentException">Thrown if the ID Number is not usable.</exception>
		public PersonGender Gender 
		{
			get 
			{
				if(IsUsable == false) 
				{
					throw new ArgumentException("ID Number is unusable!", "IDNumber");
				}
				int gender = int.Parse(_match.Groups["Gender"].Value);
				if(gender < (int) PersonGender.Male) 
				{
					return PersonGender.Female;
				} 
				else 
				{
					 return PersonGender.Male;
				}
			}
		}

		/// <summary>
		/// Indicates the citizenship for the ID number.
		/// </summary>
		/// <exception cref="System.ArgumentException">Thrown if the ID Number is not usable.</exception>
		public PersonCitizenship Citizenship 
		{
			get 
			{
				if(IsUsable == false) 
				{
					throw new ArgumentException("ID Number is unusable!", "IDNumber");
				}
				return (PersonCitizenship) Enum.Parse(typeof(PersonCitizenship), _match.Groups["Citizenship"].Value);
			}
		}

		/// <summary>
		/// Indicates if the IDNumber is usable or not.
		/// </summary>
		public bool IsUsable 
		{
			get 
			{
				return _match.Success;
			}
		}

		/// <summary>
		/// Indicates if the IDNumber is valid or not.
		/// </summary>
		public bool IsValid
		{
			get 
			{
				if(IsUsable == true) 
				{
					// Calculate total A by adding the figures in the odd positions i.e. the first, third, fifth,
					// seventh, ninth and eleventh digits.
					int a = int.Parse(_match.Value.Substring(0, 1)) + int.Parse(_match.Value.Substring(2, 1)) + int.Parse(_match.Value.Substring(4, 1)) + int.Parse(_match.Value.Substring(6, 1)) + int.Parse(_match.Value.Substring(8, 1)) + int.Parse(_match.Value.Substring(10, 1));

					// Calculate total B by taking the even figures of the number as a whole number, and then
					// multiplying that number by 2, and then add the individual figures together.
					int b = int.Parse(_match.Value.Substring(1, 1) + _match.Value.Substring(3, 1) + _match.Value.Substring(5, 1) + _match.Value.Substring(7, 1) + _match.Value.Substring(9, 1) + _match.Value.Substring(11, 1));
					b *= 2;
					string bString = b.ToString();
					b = 0;
					for(int index = 0; index < bString.Length; index++) 
					{
						b += int.Parse(bString.Substring(index, 1));
					}

					// Calculate total C by adding total A to total B.
					int c = a + b;

					// The control-figure can now be determined by subtracting the ones in figure C from 10.
					string cString = c.ToString() ;
					cString = cString.Substring(cString.Length - 1, 1) ;
					int control = 0;

					// Where the total C is a multiple of 10, the control figure will be 0.
					if(cString != "0") 
					{
						control = 10 - int.Parse(cString.Substring(cString.Length - 1, 1));
					} 

					if(_match.Groups["Control"].Value == control.ToString()) 
					{
						return true;
					}
				}

				return false;
			}
		}
		#endregion

	}
}