interface StringElement {
	type: 'String' | 'Char';
	name: string;
	minLength: number;
	maxLength: number;
	hasBigLetters: boolean;
	hasSmallLetters: boolean;
	hasDigits: boolean;
	hasSymbols: boolean;
}

export default StringElement;
