namespace CourseWork.Core.UsersActivity
{
    public sealed class UserLike : object, IDataEntity
    {
        public UserLike(int id, int collectionItemId, string userId)
        {
            Id = id;
            CollectionItemId = collectionItemId;
            UserId = userId;
        }

        public UserLike()
            : this(0, 0, string.Empty)
        {
        }

        public int Id { get; set; }

        public int CollectionItemId { get; set; }

        public string UserId { get; set; }

        public void Update(object update)
        {
            if (update == null || !(update is UserLike))
            {
                return;
            }

            UserLike temp = update as UserLike;
            CollectionItemId = temp.CollectionItemId;
            UserId = temp.UserId;
        }

        public override int GetHashCode() => Id ^ CollectionItemId ^ UserId.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is UserLike))
            {
                return false;
            }

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => Id.ToString();
    }
}
