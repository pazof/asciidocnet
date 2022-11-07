namespace AsciiDocNet;

/// <summary>
/// An keyboard macro. Requires experimental flag. More information in
/// <see cref="https://docs.asciidoctor.org/asciidoc/latest/macros/keyboard-macro/"> documentation about Keybard Macro</see>
/// </summary>
/// 
/// <example>
///		kbd:[F11]
/// </example>
/// 
/// <example>
///		|kbd:[Ctrl+Shift+N]
/// </example>
/// <seealso cref="AsciiDocNet.Media" />
public class KeyboardMacro : IInlineElement, IText, IAttributable
{
	public KeyboardMacro(string text)
	{
		Text = text;
	}

	public KeyboardMacro()
	{

	}

	public TVisitor Accept<TVisitor>(TVisitor visitor) where TVisitor : IDocumentVisitor
	{
		visitor.VisitKeyboardMacro(this);
		return visitor;
	}

	public string Text { get; set; }
	public AttributeList Attributes { get; } = new();
}