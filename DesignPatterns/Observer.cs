/*
A script to create the observer design pattern.
*/

public interface ISignalObserver
{
    public void SendNotification(string message);
}

public class MailNotificationSender : ISignalObserver
{
    public void SendNotification(string message) { }
}

public class SmsNotificationSender : ISignalObserver
{
    public void SendNotification(string message) { }
}

public class PopUpNotificationSender : ISignalObserver
{
    public void SendNotification(string message) { }
}

public interface INotificationService
{
    public void Register(ISignalObserver actionObserver);
    public void Remove(ISignalObserver actionObserver);
    public void Notify(string message);
}

public class NotificationService : INotificationService
{
    private List<ISignalObserver> listObserver = new();

    public void Register(ISignalObserver actionObserver)
    {
        listObserver.Add(actionObserver);
    }

    public void Remove(ISignalObserver actionObserver)
    {
        listObserver.Remove(actionObserver);
    }

    public void Notify(string message)
    {
        foreach (ISignalObserver signalObserver in listObserver)
        {
            signalObserver.SendNotification(message);
        }
    }
}
