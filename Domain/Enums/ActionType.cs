namespace TaskFlow.Domain.Enums
{
    public enum ActionType
    {
        TaskCreated = 1,
        TaskUpdated = 2,
        TaskDeleted = 3,
        CommentAdded = 4,
        CommentDeleted = 5,
        UserAddedToProject = 6,
        UserRemovedFromProject = 7,
    }
}
