using System;
namespace Crud.Models.Class
{
    public class User
    {
        #region Properties

        int mId = 0;
        string mName = "";
        string mLastName = "";
        string mAddress = "";
        string mEmail = "";
        DateOnly mDateOfBirth = DateOnly.MinValue;
        string mPhone = "";

        public int ID { get => mId; set => mId = value; }
        public string Name { get => mName; set => mName = value; }
        public string LastName { get => mLastName; set => mLastName = value; }
        public string Address { get => mAddress; set => mAddress = value; }
        public string Email { get => mEmail; set => mEmail = value; }
        public DateOnly Birth { get => mDateOfBirth; set => mDateOfBirth = value; }
        public string Phone { get => mPhone; set => mPhone = value; }

        #endregion
    }
}
