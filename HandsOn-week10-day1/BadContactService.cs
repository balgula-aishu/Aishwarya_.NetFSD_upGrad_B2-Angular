using System.Collections.Generic;

namespace week10_day1
{
    public class BadContactService
    {
        private List<Contact> contacts = new List<Contact>();

        public void add(Contact c)
        {
            if (c != null)
            {
                if (c.Name != "")
                {
                    contacts.Add(c);
                }
            }
        }
    }
}
