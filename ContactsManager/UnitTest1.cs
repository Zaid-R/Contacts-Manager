using System;
using Xunit;
using ContactManager;

namespace ContactManagerTests
{
    public class ContactManagerTest
    {
        public static IEnumerable<object[]> ContactData =>
            new List<object[]>
            {
                new object[] { new Contact("   Zaid Rajab ", "0782511111", ContactType.Family) },
            };

        [Theory]
        [MemberData(nameof(ContactData))]
        public void Test_AddAndDuplication(Contact contact)
        {
            // Act & Assert for Add
            object addOutput = ContactsManager.AddContact(contact);
            Assert.Equal(ContactsManager.ViewAllContacts(), addOutput);

            // Act & Assert for Duplication
            object duplicationOutput = ContactsManager.AddContact(contact);
            Assert.Equal("Contact is already exist", duplicationOutput);
        }

        [Fact]
        public void Test_Empty_Contact()
        {
            // Act 1
            object output = ContactsManager.AddContact(new Contact("", "", ContactType.Work));

            // Assert 1
            Assert.Equal("Name can't be empty.",output);

            // Act 2
            output = ContactsManager.AddContact(new Contact("", "00000", ContactType.Work));

            // Assert 2
            Assert.Equal("Name can't be empty.", output);

            // Act 3
            output = ContactsManager.AddContact(new Contact("Zaid", "", ContactType.Work));

            // Assert 3
            Assert.Equal("PhoneNumber can't be empty.", output);
        }

        [Theory]
        [MemberData(nameof(ContactData))]

        public void Test_Remove(Contact contact)
        {
            // Act
            object addOutput = ContactsManager.RemoveContact(contact.Name);
            
            // Assert
            Assert.Equal(ContactsManager.ViewAllContacts(), addOutput);
        }

        [Fact]
        public void Test_View_All()
        {
            // Act
            List<String> output = ContactsManager.ViewAllContacts();
            // Assert
            Assert.Equal(ContactsManager.ViewAllContacts(), output);
        }
    }
}