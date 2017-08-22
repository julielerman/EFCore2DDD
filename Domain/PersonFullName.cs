using JimmyBogardRocks;
//source: http://grabbagoft.blogspot.com/2007/06/generic-value-object-equality.html

namespace SamuraiApp.Domain {
  public class PersonFullName : ValueObject<PersonFullName> {

    public static PersonFullName Create (string first, string last) {
      return new PersonFullName (first, last);
    }
    public static PersonFullName Empty () {
      return new PersonFullName (null, null);
    }
    private PersonFullName () { }

    public bool IsEmpty () {
      if (string.IsNullOrEmpty (First) && string.IsNullOrEmpty (Last)) {
        return true;
      } else {
        return false;
      }
    }
    private PersonFullName (string first, string last) {
      First = first;
      Last = last;
    }

    public string First { get; private set; }
    public string Last { get; private set; }
    public string FullName () => First + " " + Last;

  }
}