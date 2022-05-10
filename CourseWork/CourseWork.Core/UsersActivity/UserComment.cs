namespace CourseWork.Core.UsersActivity
{
    public sealed class UserComment : object, IDataEntity
    {
        public UserComment(int id, int collectionItemId, string userId, string text, System.DateTime date)
        {
            Id = id;
            CollectionItemId = collectionItemId;
            UserId = userId;
            Text = text;
            Date = date;
        }

        public UserComment()
            : this(0, 0, string.Empty, string.Empty, System.DateTime.Now)
        {
        }

        public int Id { get; set; }

        public int CollectionItemId { get; set; }

        public string UserId { get; set; }

        public string Text { get; set; }

        public System.DateTime Date { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is UserComment))
            {
                return;
            }

            UserComment temp = update as UserComment;
            CollectionItemId = temp.CollectionItemId;
            UserId = temp.UserId;
            Text = temp.Text;
            Date = temp.Date;
        }

        public override int GetHashCode() => Id
            ^ CollectionItemId
            ^ UserId.GetHashCode()
            ^ Text.GetHashCode()
            ^ Date.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is UserComment))
            {
                return false;
            }

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => UserId + ": " + Text;
    }
}
