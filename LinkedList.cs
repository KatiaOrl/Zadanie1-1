using System.Collections;
using System.Collections.Generic;
using System;

namespace Zadanie1_1
{
    public class LinkedList<T> : IEnumerable<T>  // односвязный список
    {
        Node<T> head; // головной/первый элемент
        Node<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке
 
        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
 
            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;
 
            count++;
        }
        // удаление элемента
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;
 
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;
 
                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;
 
                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
 
                previous = current;
                current = current.Next;
            }
            return false;
        }
 
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        // содержит ли список элемент
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        // добвление в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        
        public void printList() {
            Node<T> current = head;
            while (current != null) 
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        
        public Node<T> getPrevious(Node<T> node) {
            Node<T> current = head;
            if (current == null) return null;
            if (node == head) return null;
            // ищем предыдущий элемент
            while (current.Next!=node)
            {
                current = current.Next;
            }
            return current;
        }
        
        public void printReversed() {
            Node<T> current = tail;
            while (current != null) 
            {
                Console.WriteLine(current.Data);
                current = getPrevious(current);
            }
        }

    }
}