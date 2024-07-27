using System;
using System.Collections.Generic;

public class TaskManager : ITaskManager
{
    private List<Task> tasks = new List<Task>();
    private int nextId = 1;

    public void AddTask(string description)
    {
        tasks.Add(new Task(nextId++, description));
    }

    public void RemoveTask(int id)
    {
        tasks.RemoveAll(task => task.Id == id);
    }

    public void CompleteTask(int id)
    {
        Task task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            task.IsCompleted = true;
        }
    }

    public List<Task> GetAllTasks() => tasks;

    public List<Task> GetPendingTasks() => tasks.FindAll(task => !task.IsCompleted);

    public List<Task> GetCompletedTasks() => tasks.FindAll(task => task.IsCompleted);
}
