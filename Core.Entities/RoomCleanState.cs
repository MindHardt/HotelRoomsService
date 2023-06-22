namespace Core.Entities;

public enum RoomCleanState
{
    /// <summary>Комната чистая</summary>
    Clean,
    /// <summary>Комната грязная, но клининг не проинформирован</summary>
    Dirty,
    /// <summary>Заказана уборка, клининг сервис знает</summary>
    CleanRequested,
}