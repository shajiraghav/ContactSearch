using ContactSearch.DomainModel;
using System;
using System.IO;
using System.Linq;

namespace ContactSearch.Utilities
{
    /// <summary>
    /// The ContactFactory class.
    /// This is just to create seed data.
    /// </summary>
    public class ContactFactory
    {
        #region Fields

        private static Random random = new Random();
        private const int CountOfModelsToCreate = 250;
        private const string namesFile = @"Names.txt";
        private string[] photoes = new string[]{"Photoes/Photo1.jpg", "Photoes/Photo2.jpg"
            , "Photoes/Photo3.jpg", "Photoes/Photo4.jpg", "Photoes/Photo5.jpg"
            , "Photoes/Photo6.jpg", "Photoes/Photo7.jpg"};
        private static int modelId = 0;
        private string[] names;
        private string[] middleNames = new string[] { "A", "B", "C", "D", "E" };
        private string[] address = new string[] { "150 King Ln", "260 SLR Ln", "370 OO Ln", "480 SDLC Ln", "590 UML Ln" };
        private string[] cities = new string[] { "Redmond", "Somerset", "Kirkland", "Bridgewater", "Tacoma" };
        private string[] states = new string[] { "WA", "NJ", "NY", "NC", "WI" };
        private string[] postalCodes = new string[] { "08873", "07873", "085873", "08846", "02873" };
        private string[] interests = new string[] { "Reading", "Soccer", "Games", "Cricket" };

        #endregion Fields

        #region Constructors

        public ContactFactory()
        {
            if (!File.Exists(namesFile))
            {
                throw new FileNotFoundException(namesFile + "not found!");
            }

            names = File.ReadAllLines(namesFile);
        }

        #endregion Constructors

        #region Methods

        #region Publics

        public ContactModel CreateContact()
        {
            var model = new ContactModel();

            model.FirstName = PickRandom(names);
            model.MiddleName = PickRandom(middleNames);
            model.LastName = PickRandom(names);
            model.DateOfBirth = RandomDay();

            model.Id = modelId++;
            model.Address = PickRandom(address);
            model.City = PickRandom(cities);
            model.State = PickRandom(states);
            model.Country = "USA";
            model.PostalCode = PickRandom(postalCodes);

            model.Interests = new string[] { PickRandom(interests), PickRandom(interests), PickRandom(interests) };
            model.Photo = ReadImage(PickRandom(photoes));

            return model;
        }

        #endregion Publics

        #region Privates

        private static string PickRandom(string[] source)
        {
            return source[random.Next(source.Count())];
        }

        private static byte[] ReadImage(string fileName)
        {
            if (!File.Exists(namesFile))
            {
                return null;
            }

            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] image = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                return image;
            }
            catch (Exception ex)
            {
                throw new Exception("Image file conversion failed!", ex);
            }
        }

        private DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        #endregion Privates

        #endregion Methods
    }
}
