/*
Test to evaluate the behaviour of Singletons.
*/

using System.Collections.Concurrent;
using DesignPattern;

namespace DesignPatterns.Test;

public class SingletonTest
{
    [Fact]
    public void Singleton_CallInstanceMultipleTimes_ReturnSameInstance()
    {
        // Arrange
        Singleton singleton = Singleton.Instance;
        Singleton singleton2 = Singleton.Instance;

        // Act

        // Assert
        Assert.Equal(singleton, singleton2);
    }

    /// <summary>
    /// Async tests return a Task.
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task SingletonInThread_CallInstanceMultipleTimes_ReturnSameInstance()
    {
        // Arrange
        int taskCount = 10;
        var instances = new ConcurrentBag<Singleton>();
        var barrier = new Barrier(taskCount);
        var tasks = new List<Task>();

        // Act
        for (int i = 0; i < taskCount; i++)
        {
            tasks.Add(
                Task.Run(() =>
                {
                    // dotnet barriers block all signals at a certain point.
                    barrier.SignalAndWait(); // Synchronize all threads to start here
                    instances.Add(Singleton.Instance);
                })
            );
        }

        await Task.WhenAll(tasks);

        // Assert
        var firstInstance = instances.First();
        Assert.All(instances, inst => Assert.Same(firstInstance, inst));
        Assert.Single(instances.Distinct());
    }

    [Fact]
    public async Task SingletonNotThreadSafe_CallInstanceMultipleTimes_ReturnDifferentInstances()
    {
        // Arrange
        int taskCount = 10;
        var instances = new ConcurrentBag<SingletonNotThreadSafe>();
        var barrier = new Barrier(taskCount);
        var tasks = new List<Task>();

        // Act
        for (int i = 0; i < taskCount; i++)
        {
            tasks.Add(
                Task.Run(() =>
                {
                    // dotnet barriers block all signals at a certain point.
                    barrier.SignalAndWait(); // Synchronize all threads to start here
                    instances.Add(SingletonNotThreadSafe.Instance);
                })
            );
        }

        await Task.WhenAll(tasks);

        // Assert
        var firstInstance = instances.First();
        Assert.False(instances.All(x => x == firstInstance));
        Assert.NotEqual(1, instances.Distinct().ToList().Count);
    }
}
