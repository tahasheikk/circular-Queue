using System;

public class CircularQueue
{
    private int size;
    private int[] queue;
    public int front;
    public int rear;

    public CircularQueue(int size)
    {
        this.size = size;
        queue = new int[size];
        front = -1;
        rear = -1;
    }

    public bool IsEmpty()
    {
        return front == -1;
    }

    public bool IsFull()
    {
        return (rear + 1) % size == front;
    }

    public string Enqueue(int value)
    {
        if (IsFull())
        {
            return "Queue is full";
        }

        if (front == -1)
        {
            front = 0;
        }

        rear = (rear + 1) % size;
        queue[rear] = value;
        return null;
    }

    public string Dequeue()
    {
        if (IsEmpty())
        {
            return "Queue is empty";
        }

        int dequeuedValue = queue[front];
        queue[front] = 0; // Optional: clear the value

        if (front == rear)
        {
            front = -1;
            rear = -1;
        }
        else
        {
            front = (front + 1) % size;
        }

        return dequeuedValue.ToString();
    }

    public string Peek()
    {
        if (IsEmpty())
        {
            return "Queue is empty";
        }
        return queue[front].ToString();
    }

    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty");
            return;
        }

        Console.Write("Queue: ");
        if (rear >= front)
        {
            for (int i = front; i <= rear; i++)
            {
                Console.Write(queue[i] + " ");
            }
        }
        else
        {
            for (int i = front; i < size; i++)
            {
                Console.Write(queue[i] + " ");
            }
            for (int i = 0; i <= rear; i++)
            {
                Console.Write(queue[i] + " ");
            }
        }
        Console.WriteLine();
    }

    public string Reverse()
    {
        if (IsEmpty())
        {
            return "Queue is empty";
        }

        int count = (rear >= front) ? (rear - front + 1) : (size - front + rear + 1);
        int[] elements = new int[count];

        // کپی کردن عناصر به آرایه
        for (int i = 0; i < count; i++)
        {
            elements[i] = queue[(front + i) % size]; // کپی کردن عناصر با استفاده از اندیس دایره‌ای
        }

        Array.Reverse(elements); // معکوس کردن آرایه

        // ریست کردن صف
        queue = new int[size];
        front = 0;
        rear = count - 1;

        // کپی کردن عناصر معکوس به صف
        for (int i = 0; i < count; i++)
        {
            queue[i] = elements[i];
        }

        return null; // هیچ خطایی نیست
    }
}

public class Program
{
    public static void Main()
    {
        CircularQueue circle = new CircularQueue(5);
        Console.WriteLine(circle.rear);
        Console.WriteLine(circle.front);
        circle.Display();

        // Adding elements to the queue
        circle.Enqueue(10);
        circle.Enqueue(20);
        circle.Enqueue(30);
        circle.Enqueue(40);
        circle.Enqueue(50);

        // Display the queue
        circle.Display();

        // Trying to enqueue when the queue is full
        Console.WriteLine(circle.Enqueue(60)); // Should indicate that the queue is full

        // Dequeue elements
        Console.WriteLine("Dequeued: " + circle.Dequeue());
        circle.Display();

        Console.WriteLine("Dequeued: " + circle.Dequeue());
        circle.Display();

        // Add a new element after dequeuing
        circle.Enqueue(60);
        circle.Display();

        // Reverse the queue
        circle.Reverse();
        circle.Display();
    }
}
