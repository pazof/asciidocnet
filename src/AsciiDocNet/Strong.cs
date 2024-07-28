using System.Linq;

namespace AsciiDocNet
{
	/// <summary>
	/// A strong element. See more in <see cref="https://docs.asciidoctor.org/asciidoc/latest/text/bold/">documentation about bold text</see>
	/// </summary>
	/// <example>
	/// *word*
	/// </example>
	/// <seealso cref="AsciiDocNet.InlineContainer" />
	/// <seealso cref="AsciiDocNet.IInlineElement" />
	/// <seealso cref="AsciiDocNet.IAttributable" />
	public class Strong : InlineContainer, IInlineElement, IAttributable
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="Strong"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="doubleDelimited">if set to <c>true</c> [double delimited].</param>
        public Strong(string text, bool doubleDelimited = false)
		{
			Add(new TextLiteral(text));
			DoubleDelimited = doubleDelimited;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Strong"/> class.
        /// </summary>
        public Strong()
		{
		}

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        public AttributeList Attributes { get; } = new AttributeList();

        /// <summary>
        /// Gets the types of elements that this inline container can contain
        /// </summary>
        /// <value>
        /// The type of elements
        /// </value>
        public override InlineElementType ContainElementType { get; } =
			InlineElementType.Literal | InlineElementType.AttributeReference | InlineElementType.Emphasis | InlineElementType.EmphasisDouble |
			InlineElementType.ImplicitLink | InlineElementType.InlineAnchor | InlineElementType.InternalAnchor | InlineElementType.Mark |
			InlineElementType.MarkDouble | InlineElementType.Monospace | InlineElementType.MonospaceDouble | InlineElementType.Quotation |
			InlineElementType.QuotationDouble | InlineElementType.Subscript | InlineElementType.Superscript;

        /// <summary>
        /// Gets or sets a value indicating whether this element is [double delimited].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [double delimited]; otherwise, <c>false</c>.
        /// </value>
        public bool DoubleDelimited { get; set; }

        /// <summary>
        /// Accepts a visitor to visit this element instance
        /// </summary>
        /// <typeparam name="TVisitor">The type of the visitor.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>
        /// The visitor
        /// </returns>
        public override TVisitor Accept<TVisitor>(TVisitor visitor)
		{
			visitor.VisitStrong(this);
			return visitor;
		}

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
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

			return obj.GetType() == this.GetType() && Equals((Strong)obj);
		}

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = DoubleDelimited.GetHashCode();
				hashCode = (hashCode * 397) ^ Attributes.GetHashCode();
				hashCode = (hashCode * 397) ^ Elements.GetHashCode();
				return hashCode;
			}
		}

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Strong left, Strong right) => Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Strong left, Strong right) => !Equals(left, right);

        /// <summary>
        /// Determines whether the specified <see cref="Strong" />, is equal to this instance.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>true if equal; otherwise, false</returns>
        protected bool Equals(Strong other) => 
            DoubleDelimited == other.DoubleDelimited &&
            Attributes.Equals(other.Attributes) &&
            Elements.SequenceEqual(other.Elements);
	}
}