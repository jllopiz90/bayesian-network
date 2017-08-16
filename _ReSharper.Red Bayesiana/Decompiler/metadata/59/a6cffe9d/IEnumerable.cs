// Type: System.Collections.IEnumerable
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;

namespace System.Collections
{
  /// <summary>
  /// Exposes the enumerator, which supports a simple iteration over a non-generic collection.
  /// </summary>
  /// <filterpriority>1</filterpriority>
  [ComVisible(true)]
  [Guid("496B0ABE-CDEE-11d3-88E8-00902754C43A")]
  public interface IEnumerable
  {
    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// 
    /// <returns>
    /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
    /// </returns>
    /// <filterpriority>2</filterpriority>
    [DispId(-4)]
    IEnumerator GetEnumerator();
  }
}
