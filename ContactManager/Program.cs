

namespace ContactManager
{
    public enum ContactType
    {
        Family,
        Friend,
        Work
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contactList = new List<Contact>
            {
                new Contact("Alice Smith", "111-222-3333", ContactType.Family),
                new Contact("Bob Smith", "111-222-4444", ContactType.Family),
                new Contact("Carol Smith", "111-222-5555", ContactType.Family),
                new Contact("David Brown", "222-333-4444", ContactType.Friend),
                new Contact("Eva Brown", "222-333-5555", ContactType.Friend),
                new Contact("Frank Brown", "222-333-6666", ContactType.Friend),
                new Contact("Grace White", "333-444-5555", ContactType.Work),
                new Contact("Henry White", "333-444-6666", ContactType.Work),
                new Contact("Ivy White", "333-444-7777", ContactType.Work)
            };

            foreach (var contact in contactList)
            {
                ContactsManager.AddContact(contact);
            }

            List<string> categoryContacts = ContactsManager.GetByCategory(ContactType.Family);
            foreach (var contact in categoryContacts)
            {
                Console.WriteLine(contact);
            }
        }
    }

    public class ContactsManager
    {
        private static List<Contact> contacts = new List<Contact>();

        public static List<String> ViewAllContacts()
        {
            return contacts.Select(contact => contact.ToString()).ToList();
        }
        public static object AddContact(Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name))
            {
                return "Name can't be empty.";
            }
            else if (string.IsNullOrWhiteSpace(contact.PhoneNumber))
            {
                return "PhoneNumber can't be empty.";
            }

            if (Search(contact.Name, true) != "Contact not found" ||
                Search(contact.PhoneNumber, false) != "Contact not found")
            {
                return "Contact is already exist";
            }

            contacts.Add(contact);
            return ViewAllContacts();
        }

        public static List<String> RemoveContact(string name)
        {
            Contact? contactToRemove = contacts.FirstOrDefault(contact => contact.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contactToRemove is not null)
            {
                contacts.Remove(contactToRemove);
            }
            return ViewAllContacts();
        }

        public static string Search(string property, bool isNameProperty)
        {
            Contact? contactToFind = contacts.FirstOrDefault(contact =>
            {
                string contactProperty = isNameProperty ? contact.Name : contact.PhoneNumber;
                return contactProperty.Equals(property, StringComparison.OrdinalIgnoreCase);
            });
            return (contactToFind is not null) ? contactToFind.ToString() : "Contact not found";
        }

        public static List<String> GetByCategory(ContactType category)
        {
            return contacts.Where(contact => contact.Type == category)
                           .Select(contact => contact.ToString())
                           .ToList();
        }
    }

    public class Contact
    {
        private string name;
        private string phoneNumber;
        private ContactType type;

        public Contact(string name, string phoneNumber, ContactType type)
        {
            this.name = name.Trim();
            this.phoneNumber = phoneNumber.Trim();
            this.type = type;
        }
        public string Name { get => name; }
        public string PhoneNumber { get => phoneNumber; }
        public ContactType Type { get => type; }

        public override string ToString()
        {
            return $"Name: {name}, Phone number: {phoneNumber}, Type: {type}";
        }
    }
}
