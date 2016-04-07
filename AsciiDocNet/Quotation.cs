using System.Collections.Generic;
using System.Linq;

namespace AsciiDocNet
{
	public class Quotation : IContainerInlineElement, IAttributable
	{
		public Quotation(string text, bool doubleDelimited = false)
		{
			Elements.Add(new TextLiteral(text));
			DoubleDelimited = doubleDelimited;
		}

		public Quotation()
		{
		}

		public AttributeList Attributes { get; } = new AttributeList();

		public InlineElementType ContainElementType { get; } =
			InlineElementType.Literal | InlineElementType.AttributeReference | InlineElementType.Emphasis | InlineElementType.EmphasisDouble |
			InlineElementType.ImplicitLink | InlineElementType.InlineAnchor | InlineElementType.InternalAnchor | InlineElementType.Mark |
			InlineElementType.MarkDouble | InlineElementType.Monospace | InlineElementType.MonospaceDouble | InlineElementType.Strong |
			InlineElementType.StrongDouble | InlineElementType.Subscript | InlineElementType.Superscript;

		public bool DoubleDelimited { get; set; }

		public IList<IInlineElement> Elements { get; } = new List<IInlineElement>();

		public static bool operator ==(Quotation left, Quotation right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Quotation left, Quotation right)
		{
			return !Equals(left, right);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			if (ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != this.GetType())
			{
				return false;
			}
			return Equals((Quotation)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Attributes.GetHashCode();
				hashCode = (hashCode * 397) ^ DoubleDelimited.GetHashCode();
				hashCode = (hashCode * 397) ^ Elements.GetHashCode();
				return hashCode;
			}
		}

		public TVisitor Accept<TVisitor>(TVisitor visitor) where TVisitor : IDocumentVisitor
		{
			visitor.Visit(this);
			return visitor;
		}

		protected bool Equals(Quotation other)
		{
			return Attributes.Equals(other.Attributes) &&
			       DoubleDelimited == other.DoubleDelimited &&
			       Elements.SequenceEqual(other.Elements);
		}
	}
}