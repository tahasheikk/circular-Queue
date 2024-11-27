using System;

public class CircularQueue
{
    private int size; // اندازه صف
    private int front; // نمای جلوی صف
    private int rear; // نمای عقب صف
    private int[] queue; // آرایه برای ذخیره عناصر صف

    // سازنده
    public CircularQueue(int size)
    {
        this.size = size;
        this.front = -1;
        this.rear = -1;
        this.queue = new int[size];
    }

    // متد برای درج یک عنصر جدید در صف
    public void enQueue(int data)
    {
        // شرط برای پر بودن صف
        if ((front == 0 && rear == size - 1) || (rear == (front - 1) % (size - 1)))
        {
            Console.WriteLine("Queue is Full");
            return;
        }

        // شرط برای صف خالی
        if (front == -1)
        {
            front = rear = 0;
            queue[rear] = data;
        }
        else if (rear == size - 1 && front != 0)
        {
            rear = 0;
            queue[rear] = data;
        }
        else
        {
            rear++;
            queue[rear] = data;
        }
    }

    // متد برای حذف یک عنصر از صف
    public int deQueue()
    {
        if (front == -1)
        {
            Console.WriteLine("Queue is Empty");
            return -1;
        }

        int temp = queue[front];
        if (front == rear)
        {
            front = rear = -1; // اگر فقط یک عنصر وجود داشته باشد
        }
        else if (front == size - 1)
        {
            front = 0;
        }
        else
        {
            front++;
        }

        return temp;
    }

    // متد برای نمایش عناصر صف
    public void displayQueue()
    {
        if (front == -1)
        {
            Console.WriteLine("Queue is Empty");
            return;
        }

        Console.Write("Elements in the circular queue are: ");
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

    // کد اصلی
    public static void Main()
    {
        CircularQueue q = new CircularQueue(5);

        q.enQueue(14);
        q.enQueue(22);
        q.enQueue(13);
        q.enQueue(-6);

        q.displayQueue();

        int x = q.deQueue();
        if (x != -1)
        {
            Console.WriteLine("Deleted value = " + x);
        }

        x = q.deQueue();
        if (x != -1)
        {
            Console.WriteLine("Deleted value = " + x);
        }

        q.displayQueue();

        q.enQueue(9);
        q.enQueue(20);
        q.enQueue(5);

        q.displayQueue();

        q.enQueue(20);
    }
}