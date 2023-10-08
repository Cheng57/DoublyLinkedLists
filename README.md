# DoublyLinkedLists #
## Classes ##
 * Employee
 * Node\<T\>
 * LinkedList\<T\>
### Employee Class ###
* Properties 
  * int EmployeeId
  * string FirstName
  * string LastName 
* Public Methods
  * Employee(int employeeId)
  * Employee(employeeId, firstName, lastName) 
  * int CompareTo(Employee other) -- Compare with other employees based on the EmployeeID. Note: Must   
    implement 
    IComparable\<Employee\>
  * override string ToString()
### Node\<T\> Class ###
* Properties
  * T Element
  * Node\<T\> Next
  * Node\<T\> Previous
* Public Methods
  * Node()
  * Node(T element)
  * Node(T element, Node\<T\> previous, Node\<T\> next)
### LinkedList\<T\> ###
Must be able to use the object's 'CompareTo' method to compare objects. Not 'Equals' method that is finding the exact same object.
* Properties
  * Head -- Points to the first node in the list(or null if there are no nodes)
  * Tail -- Points to the last node in the list(or null if there are no nodes)
  * Size -- Count of the number of nodes in the list, zero when the list is empty
* Public Methods
  * LinkedList()
  * void Clear()
  * T GetFirst()
  * T GetLast()
  * T SetFirst(T element)
  * T SetLast(T element)
  * void AddFirst(T element)
  * void AddLast(T element)
  * T RemoveFirst()
  * T RemoveLast()
  * T Get(int position)
  * T Remove(int position)
  * T Set(T element, int position)
  * void AddAfter(T element, int position)
  * void AddBefore(T element, int position)
  * T Remove(T element)
  * T Set(T element, T oldElement)
  * void Insert(T element)
  * void SortAscending()
