using Xunit;

namespace AsciiDocNet.Tests.Unit
{
	public class InlineTests
	{
		[Fact]
		public void Test()
		{
			var input = "This is a paragraph with **strong** and _emphasis_ text with `monospace` too!";

			var document = Document.Parse(input);

		}

		[Theory]
		[InlineData("kbd:[F11]")]
		[InlineData("kbd:[Ctrl+T]")]
		[InlineData("kbd:[Ctrl+Shift+N]")]
		[InlineData("kbd:[\\]")]
		[InlineData("kbd:[Ctrl+\\]]")]
		[InlineData("kbd:[Ctrl + +]")]
		public void ParsingKeyboardMacro(string input)
		{
			var document = Document.Parse(input)[0] as Paragraph;
			var element = document[0] as IText;

			Assert.Equal(input, element.Text);

		}
	}
}