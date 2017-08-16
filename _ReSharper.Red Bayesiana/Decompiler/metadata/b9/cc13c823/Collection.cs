// Type: System.Collections.ObjectModel.Collection`1
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;
using System.Runtime.InteropServices;

namespace System.Collections.ObjectModel
{
  /// <summary>
  /// Provides the base class for a generic collection.
  /// </summary>
  /// <typeparam name="T">The type of elements in the collection.</typeparam>
  [DebuggerDisplay("Count = {Count}")]
  [DebuggerTypeProxy(typeof (Mscorlib_CollectionDebugView<>))]
  [ComVisible(false)]
  [Serializable]
  public class Collection<T> : IList<T>, ICollection<T>, IList, ICollection, IReadOnlyList<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.Collections.ObjectModel.Collection`1"/> class that is empty.
    /// </summary>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public Collection();
    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.Collections.ObjectModel.Collection`1"/> class as a wrapper for the specified list.
    /// </summary>
    /// <param name="list">The list that is wrapped by the new collection.</param><exception cref="T:System.ArgumentNullException"><paramref name="list"/> is null.</exception>
    public Collection(IList<T> list);
    /// <summary>
    /// Adds an object to the end of the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </summary>
    /// <param name="item">The object to be added to the end of the <see cref="T:System.Collections.ObjectModel.Collection`1"/>. The value can be null for reference types.</param>
    public void Add(T item);
    /// <summary>
    /// Removes all elements from the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </summary>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public void Clear();
    /// <summary>
    /// Copies the entire <see cref="T:System.Collections.ObjectModel.Collection`1"/> to a compatible one-dimensional <see cref="T:System.Array"/>, starting at the specified index of the target array.
    /// </summary>
    /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.ObjectModel.Collection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param><param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param><exception cref="T:System.ArgumentNullException"><paramref name="array"/> is null.</exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.</exception><exception cref="T:System.ArgumentException">The number of elements in the source <see cref="T:System.Collections.ObjectModel.Collection`1"/> is greater than the available space from <paramref name="index"/> to the end of the destination <paramref name="array"/>.</exception>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public void CopyTo(T[] array, int index);
    /// <summary>
    /// Determines whether an element is in the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </summary>
    /// 
    /// <returns>
    /// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.ObjectModel.Collection`1"/>; otherwise, false.
    /// </returns>
    /// <param name="item">The object to locate in the <see cref="T:System.Collections.ObjectModel.Collection`1"/>. The value can be null for reference types.</param>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public bool Contains(T item);
    /// <summary>
    /// Returns an enumerator that iterates through the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </summary>
    /// 
    /// <returns>
    /// An <see cref="T:System.Collections.Generic.IEnumerator`1"/> for the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </returns>
    public IEnumerator<T> GetEnumerator();
    /// <summary>
    /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </summary>
    /// 
    /// <returns>
    /// The zero-based index of the first occurrence of <paramref name="item"/> within the entire <see cref="T:System.Collections.ObjectModel.Collection`1"/>, if found; otherwise, -1.
    /// </returns>
    /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.List`1"/>. The value can be null for reference types.</param>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public int IndexOf(T item);
    /// <summary>
    /// Inserts an element into the <see cref="T:System.Collections.ObjectModel.Collection`1"/> at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param><param name="item">The object to insert. The value can be null for reference types.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.-or-<paramref name="index"/> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"/>.</exception>
    public void Insert(int index, T item);
    /// <summary>
    /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </summary>
    /// 
    /// <returns>
    /// true if <paramref name="item"/> is successfully removed; otherwise, false.  This method also returns false if <paramref name="item"/> was not found in the original <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </returns>
    /// <param name="item">The object to remove from the <see cref="T:System.Collections.ObjectModel.Collection`1"/>. The value can be null for reference types.</param>
    public bool Remove(T item);
    /// <summary>
    /// Removes the element at the specified index of the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </summary>
    /// <param name="index">The zero-based index of the element to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.-or-<paramref name="index"/> is equal to or greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"/>.</exception>
    public void RemoveAt(int index);
    /// <summary>
    /// Removes all elements from the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </summary>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    protected virtual void ClearItems();
    /// <summary>
    /// Inserts an element into the <see cref="T:System.Collections.ObjectModel.Collection`1"/> at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param><param name="item">The object to insert. The value can be null for reference types.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.-or-<paramref name="index"/> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"/>.</exception>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    protected virtual void InsertItem(int index, T item);
    /// <summary>
    /// Removes the element at the specified index of the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </summary>
    /// <param name="index">The zero-based index of the element to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.-or-<paramref name="index"/> is equal to or greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"/>.</exception>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    protected virtual void RemoveItem(int index);
    /// <summary>
    /// Replaces the element at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element to replace.</param><param name="item">The new value for the element at the specified index. The value can be null for reference types.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.-or-<paramref name="index"/> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"/>.</exception>
    protected virtual void SetItem(int index, T item);
    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// 
    /// <returns>
    /// An <see cref="T:System.Collections.IEnumerator"/> that can be used to iterate through the collection.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator();
    /// <summary>
    /// Copies the elements of the <see cref="T:System.Collections.ICollection"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
    /// </summary>
    /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param><param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param><exception cref="T:System.ArgumentNullException"><paramref name="array"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than zero. </exception><exception cref="T:System.ArgumentException"><paramref name="array"/> is multidimensional.-or-<paramref name="array"/> does not have zero-based indexing.-or-The number of elements in the source <see cref="T:System.Collections.ICollection"/> is greater than the available space from <paramref name="index"/> to the end of the destination <paramref name="array"/>.-or-The type of the source <see cref="T:System.Collections.ICollection"/> cannot be cast automatically to the type of the destination <paramref name="array"/>.</exception>
    void ICollection.CopyTo(Array array, int index);
    /// <summary>
    /// Adds an item to the <see cref="T:System.Collections.IList"/>.
    /// </summary>
    /// 
    /// <returns>
    /// The position into which the new element was inserted.
    /// </returns>
    /// <param name="value">The <see cref="T:System.Object"/> to add to the <see cref="T:System.Collections.IList"/>.</param><exception cref="T:System.ArgumentException"><paramref name="value"/> is of a type that is not assignable to the <see cref="T:System.Collections.IList"/>.</exception>
    int IList.Add(object value);
    /// <summary>
    /// Determines whether the <see cref="T:System.Collections.IList"/> contains a specific value.
    /// </summary>
    /// 
    /// <returns>
    /// true if the <see cref="T:System.Object"/> is found in the <see cref="T:System.Collections.IList"/>; otherwise, false.
    /// </returns>
    /// <param name="value">The <see cref="T:System.Object"/> to locate in the <see cref="T:System.Collections.IList"/>.</param><exception cref="T:System.ArgumentException"><paramref name="value"/> is of a type that is not assignable to the <see cref="T:System.Collections.IList"/>.</exception>
    bool IList.Contains(object value);
    /// <summary>
    /// Determines the index of a specific item in the <see cref="T:System.Collections.IList"/>.
    /// </summary>
    /// 
    /// <returns>
    /// The index of <paramref name="value"/> if found in the list; otherwise, -1.
    /// </returns>
    /// <param name="value">The <see cref="T:System.Object"/> to locate in the <see cref="T:System.Collections.IList"/>.</param><exception cref="T:System.ArgumentException"><paramref name="value"/> is of a type that is not assignable to the <see cref="T:System.Collections.IList"/>.</exception>
    int IList.IndexOf(object value);
    /// <summary>
    /// Inserts an item into the <see cref="T:System.Collections.IList"/> at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param><param name="value">The <see cref="T:System.Object"/> to insert into the <see cref="T:System.Collections.IList"/>.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.IList"/>. </exception><exception cref="T:System.ArgumentException"><paramref name="value"/> is of a type that is not assignable to the <see cref="T:System.Collections.IList"/>.</exception>
    void IList.Insert(int index, object value);
    /// <summary>
    /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList"/>.
    /// </summary>
    /// <param name="value">The <see cref="T:System.Object"/> to remove from the <see cref="T:System.Collections.IList"/>.</param><exception cref="T:System.ArgumentException"><paramref name="value"/> is of a type that is not assignable to the <see cref="T:System.Collections.IList"/>.</exception>
    void IList.Remove(object value);
    /// <summary>
    /// Gets the number of elements actually contained in the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </summary>
    /// 
    /// <returns>
    /// The number of elements actually contained in the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </returns>
    public int Count { [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")] get; }
    /// <summary>
    /// Gets a <see cref="T:System.Collections.Generic.IList`1"/> wrapper around the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </summary>
    /// 
    /// <returns>
    /// A <see cref="T:System.Collections.Generic.IList`1"/> wrapper around the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </returns>
    protected IList<T> Items { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get; }
    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// 
    /// <returns>
    /// The element at the specified index.
    /// </returns>
    /// <param name="index">The zero-based index of the element to get or set.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.-or-<paramref name="index"/> is equal to or greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"/>. </exception>
    public T this[int index] { [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")] get; set; }
    /// <summary>
    /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
    /// </summary>
    /// 
    /// <returns>
    /// true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.  In the default implementation of <see cref="T:System.Collections.ObjectModel.Collection`1"/>, this property always returns false.
    /// </returns>
    bool ICollection<T>.IsReadOnly { get; }
    /// <summary>
    /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe).
    /// </summary>
    /// 
    /// <returns>
    /// true if access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe); otherwise, false.  In the default implementation of <see cref="T:System.Collections.ObjectModel.Collection`1"/>, this property always returns false.
    /// </returns>
    bool ICollection.IsSynchronized { get; }
    /// <summary>
    /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
    /// </summary>
    /// 
    /// <returns>
    /// An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.  In the default implementation of <see cref="T:System.Collections.ObjectModel.Collection`1"/>, this property always returns the current instance.
    /// </returns>
    object ICollection.SyncRoot { get; }
    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// 
    /// <returns>
    /// The element at the specified index.
    /// </returns>
    /// <param name="index">The zero-based index of the element to get or set.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.IList"/>.</exception><exception cref="T:System.ArgumentException">The property is set and <paramref name="value"/> is of a type that is not assignable to the <see cref="T:System.Collections.IList"/>.</exception>
    object IList.this[int index] { get; set; }
    /// <summary>
    /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> is read-only.
    /// </summary>
    /// 
    /// <returns>
    /// true if the <see cref="T:System.Collections.IList"/> is read-only; otherwise, false.  In the default implementation of <see cref="T:System.Collections.ObjectModel.Collection`1"/>, this property always returns false.
    /// </returns>
    bool IList.IsReadOnly { get; }
    /// <summary>
    /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> has a fixed size.
    /// </summary>
    /// 
    /// <returns>
    /// true if the <see cref="T:System.Collections.IList"/> has a fixed size; otherwise, false.  In the default implementation of <see cref="T:System.Collections.ObjectModel.Collection`1"/>, this property always returns false.
    /// </returns>
    bool IList.IsFixedSize { get; }
  }
}
