using System;
using System.Collections.Generic;


namespace DoublyLinkedLists
{
    /// <summary>
    /// Represents a linkedlist.
    /// </summary>
    /// <typeparam name="T">Data type for the element in the list.</typeparam>
    public class LinkedList<T> where T : IComparable<T>
    {
        /// <summary>
        /// Initializes an instance of LinkedList with default properties.
        /// </summary>
        public LinkedList()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        /// <summary>
        /// Gets or sets the head of the list.
        /// </summary>
        public Node<T> Head
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the tail of the list.
        /// </summary>
        public Node<T> Tail
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the size of the list.
        /// </summary>
        public int Size
        {
            get; set;
        }

        /// <summary>
        /// Resets the linkedlist to its first instantiated state.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        /// <summary>
        /// Returns true if the list is empty otherwise false.
        /// </summary>
        /// <returns>True if the list is empty, false otherwise.</returns>
        public bool IsEmpty()
        {
            return Head == null;
        }

        /// <summary>
        /// Throws an exception when the list is empty.
        /// </summary>
        private void EmptyListThrowException()
        {
            if (IsEmpty())
            {
                throw new ApplicationException("The list is empty.");
            }
        }

        /// <summary>
        /// Throws an exception when the element is null.
        /// </summary>
        /// <param name="element"></param>
        private void NullElementThrowException(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Null element is not allowed.");
            }
        }

        /// <summary>
        /// Throws an exception when the position is invalid.
        /// </summary>
        /// <param name="position"></param>
        private void InvalidPositionThrowException(int position)
        {
            if (position <= 0 || position > Size)
            {
                throw new ApplicationException("The position provided is not valid: zero, negative or above the size of the list.");
            }
        }

        /// <summary>
        /// Returns the head's element.
        /// </summary>
        /// <returns>The head's element.</returns>
        public T GetFirst()
        {
            EmptyListThrowException();

            return Head.Element;
        }

        /// <summary>
        /// Returns the tail's element.
        /// </summary>
        /// <returns>The tail's element.</returns>
        public T GetLast()
        {
            EmptyListThrowException();

            return Tail.Element;
        }

        /// <summary>
        /// Sets the head a new element and returns the head's old element.
        /// </summary>
        /// <param name="element">The head's new element.</param>
        /// <returns>the head's old element.</returns>
        public T SetFirst(T element)
        {
            NullElementThrowException(element);
            
            EmptyListThrowException();

            T oldElement = Head.Element;
            Head.Element = element;
            return oldElement;
        }

        /// <summary>
        /// Sets the tail a new element and returns the tail's old element.
        /// </summary>
        /// <param name="element">The tail's new element.</param>
        /// <returns>The tail's old element.</returns>
        public T SetLast(T element)
        {
            NullElementThrowException(element);

            EmptyListThrowException();
              
            T oldElement = Tail.Element;
            Tail.Element = element;

            return oldElement;     
        }

        /// <summary>
        /// Adds a node to the first node of the linkedlist.
        /// </summary>
        /// <param name="element">The node's element.</param>
        public void AddFirst(T element)
        {
            Node<T> temp = new Node<T>(element);

            NullElementThrowException(element);

            if (IsEmpty())
            {
                Head = temp;
                Tail = temp;
            }
            else
            {
                temp.Next = Head;
                Head.Previous = temp;
                Head = temp;
            }

            Size++;  
        }

        /// <summary>
        /// Adds a node to the last node of the linkedlist.
        /// </summary>
        /// <param name="element">The node's element.</param>
        public void AddLast(T element)
        {
            Node<T> temp = new Node<T>(element);

            NullElementThrowException(element);

            if (IsEmpty())
            {
                Head = temp;
                Tail = temp;
            }
            else
            {
                temp.Previous = Tail;
                Tail.Next = temp;
                Tail = temp;
            }

            Size++;  
        }

        /// <summary>
        /// Removes the first node in the list and returns its element.
        /// </summary>
        /// <returns>The removed node's element.</returns>
        public T RemoveFirst()
        {
            EmptyListThrowException();

            T removedElement = Head.Element;

            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Previous = null;
            }

            Size--;

            return removedElement;
        }

        /// <summary>
        /// Removes the last node in the list and returns its element.
        /// </summary>
        /// <returns>The removed node's element.</returns>
        public T RemoveLast()
        {
            EmptyListThrowException();

            T removedElement = Tail.Element;

            if(Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }

            Size--;

            return removedElement;
        }

        /// <summary>
        /// Returns the node by its position in the list.
        /// </summary>
        /// <param name="position">The node's position in the list.</param>
        /// <returns>The node in the list.</returns>
        private Node<T> GetNodeByPosition(int position)
        {
            EmptyListThrowException();

            InvalidPositionThrowException(position);
            if (position == 1)
            {
                return Head;
            }
            else
            {
                return GetNodeByPosition(position - 1).Next;
            }
        }

        /// <summary>
        /// Returns the element of the node at the specified position.
        /// </summary>
        /// <param name="position">The position of the node in the list.</param>
        /// <returns>The elemment of the node.</returns>
        public T Get(int position)
        {
            Node<T> node = GetNodeByPosition(position);
            return node.Element;
        }

        /// <summary>
        /// Returns the element of the removed node at the specified position.
        /// </summary>
        /// <param name="position">The position of the removed node in the list.</param>
        /// <returns>The element of the removed node.</returns>
        public T Remove(int position)
        {
            Node<T> removedNode;

            EmptyListThrowException();

            InvalidPositionThrowException(position);
    
            if (Size == 1)
            {
                removedNode = Head;
                Clear();
                    
            }
            else
            {
                if (position == 1)
                {
                    removedNode = Head;
                    Head = Head.Next;
                    Head.Previous = null;
                       
                }
                else if  (position == Size)
                {
                    removedNode = Tail;
                    Tail = Tail.Previous;
                    Tail.Next = null;
           
                }
                else
                {
                    removedNode = GetNodeByPosition(position);
                    removedNode.Previous.Next = removedNode.Next;
                    removedNode.Next.Previous = removedNode.Previous;
                        
                }
                Size--;
            }
            return removedNode.Element;    
        }

        /// <summary>
        /// Replaces the element of the node at the specified position with a new element and returns the old element.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public T Set(T element, int position)
        {
            Node<T> replacedNode;
            T replacedNodeOldElement;

            NullElementThrowException(element);
           
            replacedNode = GetNodeByPosition(position);
            replacedNodeOldElement = replacedNode.Element;
            replacedNode.Element = element;
           
            return replacedNodeOldElement;
        }

        /// <summary>
        /// Adds a new node after the node at the specified position.
        /// </summary>
        /// <param name="element">The element of the new node.</param>
        /// <param name="position">The position of the node to add after.</param>
        public void AddAfter(T element, int position)
        {
            Node<T> nodeToAdd = new Node<T>(element);
            Node<T> nodeToAddAfter = GetNodeByPosition(position);

            EmptyListThrowException();

            InvalidPositionThrowException(position);

            NullElementThrowException(element);

            if (position == Size)
            {
               AddLast(element);
            }
            else
            {
                nodeToAdd.Previous = nodeToAddAfter;
                nodeToAdd.Next = nodeToAddAfter.Next;
                nodeToAddAfter.Next.Previous = nodeToAdd;
                nodeToAddAfter.Next = nodeToAdd;

                Size++;
            }
        }

        /// <summary>
        /// Adds a new node before the node at the specified position.
        /// </summary>
        /// <param name="element">The element of the new node.</param>
        /// <param name="position">The position of the node to add after.</param>
        public void AddBefore(T element, int position)
        {
            Node<T> nodeToAdd = new Node<T>(element);
            Node<T> nodeToAddBefore = GetNodeByPosition(position);

            EmptyListThrowException();

            InvalidPositionThrowException(position);

            NullElementThrowException(element);

            if (position == 1)
            {
                AddFirst(element);
            }
            else
            {
                nodeToAdd.Next = nodeToAddBefore;
                nodeToAdd.Previous = nodeToAddBefore.Previous;
                nodeToAddBefore.Previous.Next = nodeToAdd;
                nodeToAddBefore.Previous = nodeToAdd;

                Size++;
            }  
        }

        /// <summary>
        /// Returns the first node found with the specified element.
        /// </summary>
        /// <param name="element">The specified element.</param>
        /// <returns>The first node found.</returns>
        private Node<T> GetNodeByElement(T element)
        {
            Node<T> currentNode = Head;

            EmptyListThrowException();

            NullElementThrowException(element);

            while (currentNode != null)
            {
                if (element.CompareTo(currentNode.Element) == 0)
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            throw new ApplicationException("This element does not exist in the list.");
        }

        /// <summary>
        /// Returns the element of the first node found with the specified element.
        /// </summary>
        /// <param name="element">The specified element.</param>
        /// <returns>The element of the first node found.</returns>
        public T Get(T element)
        {
            Node<T> node = GetNodeByElement(element);
            return node.Element;
        }

        /// <summary>
        /// Removes the first node found with the specified element and returns the element of the removed node.
        /// </summary>
        /// <param name="element">The specified element.</param>
        /// <returns>The element of the removed node.</returns>
        public T Remove(T element)
        {
            EmptyListThrowException();

            NullElementThrowException(element);

            Node<T> node = GetNodeByElement(element);

            if (Size == 1)
            {
                Clear();
            }
            else
            {
                if (Size == 2)
                {
                    if (node == Head)
                    {
                        Head.Next.Previous = null;
                        Head = Tail;
                    }
                    else if (node == Tail)
                    {
                        Tail.Previous.Next = null;
                        Tail = Head;
                    }
                }
                else
                {
                    if (node == Head)
                    {

                        Head.Next.Previous = null;
                        Head = Head.Next;
                    }
                    else if (node == Tail)
                    {
                        Tail = Tail.Previous;
                        Tail.Next = null;
                    }
                    else
                    {
                        node.Previous.Next = node.Next;
                        node.Next.Previous = node.Previous;
                    }
                }

                Size--;
            }

                return node.Element;
        }

        /// <summary>
        /// Finds the first node found with the specified oldElement and replaces the element on that node with a new element
        /// Returns the original element of the node.
        /// </summary>
        /// <param name="element">The new element.</param>
        /// <param name="oldElement">The specified oldElement.</param>
        /// <returns>The original element of the element-replaced node found.</returns>
        public T Set(T element, T oldElement)
        {
            EmptyListThrowException();
            NullElementThrowException(oldElement);
            NullElementThrowException(element);

            Node<T> node = GetNodeByElement(oldElement);
            T originalElement = node.Element;

            node.Element = element;

            return originalElement;
        }

        /// <summary>
        /// Adds a new node with the specified element after the first node found with the specified oldElement.
        /// </summary>
        /// <param name="element">The specified element of the new node.</param>
        /// <param name="oldElement">The specified oldElement of the node found.</param>
        public void AddAfter(T element, T oldElement)
        {
            EmptyListThrowException();
            NullElementThrowException(oldElement);
            NullElementThrowException(element);

            Node<T> nodeToAdd = new Node<T>(element);
            Node<T> nodeToAddAfter = GetNodeByElement(oldElement);

            if (nodeToAddAfter == Tail)
            {
                nodeToAdd.Previous = Tail;
                nodeToAdd.Next = null;
                Tail.Next = nodeToAdd;
                Tail = nodeToAdd;
            }
            else
            {
                nodeToAdd.Previous = nodeToAddAfter;
                nodeToAdd.Next = nodeToAddAfter.Next;
                nodeToAddAfter.Next.Previous = nodeToAdd;
                nodeToAddAfter.Next = nodeToAdd;
            }

            Size++;
        }

        /// <summary>
        /// Adds a new node with the specified element before the first node found with the specified oldElement.
        /// </summary>
        /// <param name="element">The specified element of the new node.</param>
        /// <param name="oldElement">The specified oldElement of the node found.</param>
        public void AddBefore(T element, T oldElement)
        {
            EmptyListThrowException();
            NullElementThrowException(oldElement);
            NullElementThrowException(element);

            Node<T> nodeToAdd = new Node<T>(element);
            Node<T> nodeToAddBefore = GetNodeByElement(oldElement);

            if (nodeToAddBefore == Head)
            {
                nodeToAdd.Next = Head;
                nodeToAdd.Previous = null;
                Head.Previous = nodeToAdd;
                Head = nodeToAdd;
            }
            else
            {
                nodeToAdd.Next = nodeToAddBefore;
                nodeToAdd.Previous = nodeToAddBefore.Previous;
                nodeToAddBefore.Previous.Next = nodeToAdd;
                nodeToAddBefore.Previous = nodeToAdd;
            }

            Size++;
        }

        /// <summary>
        /// Adds the specified element into the linked list in natural ascending order.
        /// </summary>
        /// <param name="element">The specified element.</param>
        public void Insert(T element)
        {
            NullElementThrowException(element);

            Node<T> node = new Node<T>(element);
            Node<T> currentNode = Head;

            if (IsEmpty())
            {
                // If the list is empty, set Head and Tail to the new node.
                Head = node;
                Tail = node;
                Size++;
                return; // Return early since the list is empty.
            }

            // Find the correct position to insert the new node.
            while (currentNode != null && node.Element.CompareTo(currentNode.Element) > 0)
            {
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                // If the new element is the largest, insert it at the end.
                Tail.Next = node;
                node.Previous = Tail;
                Tail = node;
            }
            else if (currentNode.Previous == null)
            {
                // If the new element is the smallest, insert it at the beginning.
                node.Next = Head;
                Head.Previous = node;
                Head = node;
            }
            else
            {
                // Insert the new element between two nodes.
                node.Previous = currentNode.Previous;
                node.Next = currentNode;
                currentNode.Previous.Next = node;
                currentNode.Previous = node;
            }

            Size++;
        }
        
        /// <summary>
        /// Sorts the elements into ascending order.
        /// </summary>
        public void SortAscending()
        {
            if (Size <= 1)
            {
                // If the list is empty or has only one element, it's already sorted.
                return;
            }

            bool swapped;
            Node<T> current;
            Node<T> lastSorted = null;

            do
            {
                swapped = false;
                current = Head;

                while (current != lastSorted)
                {
                    if (current.Next != null && current.Element.CompareTo(current.Next.Element) > 0)
                    {
                        // Swap current and current.Next
                        T temp = current.Element;
                        current.Element = current.Next.Element;
                        current.Next.Element = temp;

                        swapped = true;
                    }

                    current = current.Next;
                }

                lastSorted = current;
            } while (swapped);
        }
    }
}