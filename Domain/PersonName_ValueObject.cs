using JimmyBogardRocks;
//source: http://grabbagoft.blogspot.com/2007/06/generic-value-object-equality.html

namespace SamuraiApp.Domain {
  public class PersonName : ValueObject<PersonName> {

    public static PersonName Create (string first, string last) {
      return new PersonName (first, last);
    }
    public static PersonName Empty () {
      return new PersonName (null, null);
    }
    private PersonName () { }

    public bool IsEmpty () {
      if (string.IsNullOrEmpty (First) && string.IsNullOrEmpty (Last)) {
        return true;
      } else {
        return false;
      }
    }
    private PersonName (string first, string last) {
      First = first;
      Last = last;
    }

    public string First { get; private set; }
    public string Last { get; private set; }
    public string FullName () => First + " " + Last;

  }
}